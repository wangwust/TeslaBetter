using System;
using System.Threading;
using System.Threading.Tasks;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Client.Service
{
    /// <summary>
    /// 主任务
    /// </summary>
    public class MainWork
    {
        /// <summary>
        /// 开始执行
        /// </summary>
        public void Run()
        {
            Log4NetHelper.Info(typeof(MainWork), $"客户端已经启动");
            try
            {
                this.Start();
            }
            catch (Exception ex)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.ERROR, $"客户端执行异常：{ex.ToString()}", SourceEnum.Client, "");
            }
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        private void Start()
        {
            AppTask appTask = TaskApp.GetOne();
            if (appTask == null)
            {
                Log4NetHelper.Info(typeof(MainWork), "没有可用的任务");
                Thread.Sleep(5 * 60 * 1000);
                return;
            }

            string errorMsg = string.Empty;
            if (!TeslaHelper.CheckTaskParam(appTask, ref errorMsg))
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Client, "");
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            Log4NetHelper.Info(typeof(MainWork), $"[客户端]开始执行任务：{appTask.Name}");
            ApiResponse<LoginReponse> response = this.Login(appTask);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, $"登录失败。信息" + response.msg, SourceEnum.Client, appTask.ClientUserName);
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            LoginReponse loginResponse = response.data;
            this.BetByMysql(appTask, loginResponse);
        }

        /// <summary>
        /// 使用mysql轮询获取投注参数
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        private void BetByMysql(AppTask task, LoginReponse loginResponse)
        {
            while (true)
            {
                try
                {
                    task = task.Update();
                    string errorMsg = string.Empty;
                    if (!TeslaHelper.CheckTaskParam(task, ref errorMsg))
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Client, task.ClientUserName);
                        Thread.Sleep(5 * 60 * 1000);
                        continue;
                    }

                    AppBetParam betParam = BetParamApp.GetOne();
                    if (betParam == null)
                    {
                        Thread.Sleep(10 * 1000);
                        continue;
                    }

                    BetParams param = betParam.BetParam;
                    if (param == null)
                    {
                        this.DeleteBetParam(task, betParam);
                        Thread.Sleep(10 * 1000);
                        continue;
                    }

                    bool flag = this.Bet(task, loginResponse, param);
                    if (flag)
                    {
                        this.DeleteBetParam(task, betParam);
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[客户端]投注异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);

                }
            }
        }

        /// <summary>
        /// 使用MQ推送参数
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        private void BetByMQ(AppTask task, LoginReponse loginResponse)
        {
            try
            {
                RabbitMQHelper.Receive<BetParams>(MQConfig.BetExchange, "topic", "", MQConfig.BetQueue, param =>
                {
                    return this.Bet(task, loginResponse, param);
                });
            }
            catch (Exception ex)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[客户端]投注异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);
            }
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="param"></param>
        private bool Bet(AppTask task, LoginReponse loginResponse, BetParams param)
        {
            if (param == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(param.Issue) || string.IsNullOrEmpty(param.BetInfo))
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"投注失败。参数有误。实体：{param.ToJson()}", SourceEnum.Client, task.ClientUserName);
                return true;
            }

            param.UserName = loginResponse.userName;
            param.Token = loginResponse.token;
            param.PlatformId = TeslaHelper.GetPlatformId(task.ClientCode);
            param.BetApi = task.ClientApi;

            try
            {
                decimal clientBalance = TeslaHelper.GetBalance(task.ClientApi, loginResponse);
                ApiResponse<BetResponse> response = BetHelper.Bet(param);
                if (response.IsSucceed)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{param.Issue}]期[客户端]投注成功。投注总额：{param.NumList.Count * task.SingleMoney}。投注信息：{param.ToJson()}", SourceEnum.Client, task.ClientUserName);
                    TeslaHelper.SaveBetOrder(task, param.NumList, param.Issue, clientBalance, SourceEnum.Client);

                    decimal balance = TeslaHelper.GetBalance(task.ClientApi, loginResponse);
                    if (balance < task.SingleMoney * (49 - task.ServerMinNumCount))
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]余额仅剩{balance}，任务停止。", SourceEnum.Client, task.ClientUserName);
                        TeslaHelper.StopTask(task.ID, TaskStopReason.ClientMoney);
                    }

                    return true;
                }

                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"第[{param.Issue}]期[客户端]投注失败。信息：" + response.msg, SourceEnum.Client, task.ClientUserName);
                if (response.msg.Contains("余额"))
                {
                    TeslaHelper.StopTask(task.ID, TaskStopReason.ClientMoney);
                    return true;
                }

                if (response.msg.ToLower().Contains("token"))
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"当前用户已掉线，即将重新登录", SourceEnum.Client, task.ClientUserName);
                    ApiResponse<LoginReponse> newLogin = this.Login(task);
                    if (newLogin.IsSucceed)
                    {
                        loginResponse = newLogin.data;
                        return false;
                    }
                    else
                    {
                        TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
                        return true;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 删除投注参数
        /// </summary>
        /// <param name="betParam"></param>
        private void DeleteBetParam(AppTask task, AppBetParam betParam)
        {
            int result = BetParamApp.Delete(betParam.ID);
            if (result < 0)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"删除投注参数失败。实体：{betParam.ToJson()}", SourceEnum.Client, task.ClientUserName);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private ApiResponse<LoginReponse> Login(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.ClientUserName,
                Password = task.ClientUserPwd,
                LoginApi = task.ClientApi,
                PlatformId = TeslaHelper.GetPlatformId(task.ClientCode),
                ClientType = task.ClientDeviceType
            };

            int loops = 10, index = 0;
            ApiResponse<LoginReponse> response = null;
            while (index < loops)
            {
                try
                {
                    response = LoginHelper.Login(param);
                    break;
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户登录异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);
                    index++;
                    Thread.Sleep(10 * 1000);
                }
            }

            if (response == null)
            {
                response = new ApiResponse<LoginReponse> { msg = "登录失败", code = -1 };
            }

            return response;
        }
    }
}
