using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Server.Service
{
    /// <summary>
    /// 主任务
    /// </summary>
    public class MainWork
    {
        private LoginResponse _loginResponse;

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Run()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"服务端已经启动", SourceEnum.Server, "");
            try
            {
                this.Start();
            }
            catch (Exception ex)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.ERROR, $"服务端执行异常：{ex.ToString()}", SourceEnum.Server, "");
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"服务端已经停止", SourceEnum.Server, "");
        }

        /// <summary>
        /// 执行
        /// </summary>
        private void Start()
        {
            AppTask appTask = TaskApp.GetOne();
            if (appTask == null)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.WARN, "没有可执行的任务", SourceEnum.Server, "");
                Thread.Sleep(5 * 60 * 1000);
                return;
            }

            string errorMsg = string.Empty;
            if (!TeslaHelper.CheckTaskParam(appTask, ref errorMsg))
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Server, "");
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"服务端开始执行任务：{appTask.Name}", SourceEnum.Server, "");
            ApiResponse<LoginResponse> response = this.Login(appTask);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, $"登录失败。信息" + response.msg, SourceEnum.Server, appTask.ServerUserName);
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            this._loginResponse = response.data;
            this.Bet(appTask);
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="task"></param>
        private void Bet(AppTask task)
        {
            List<string> bettedIssueList = new List<string>();
            while (true)
            {
                try
                {
                    if (DateTime.Now.Hour == 4)
                    {
                        bettedIssueList.Clear();
                    }

                    task = task.Update();
                    string errorMsg = string.Empty;
                    if (!TeslaHelper.CheckTaskParam(task, ref errorMsg))
                    {
                        Thread.Sleep(10 * 1000);
                        continue;
                    }

                    if (DateTime.Now.Hour < task.StartHour || DateTime.Now.Hour > task.EndHour)
                    {
                        Thread.Sleep(60 * 60 * 1000);
                        continue;
                    }

                    IssueInfo issueInfo = OpenTimeHelper.GetIssueInfo();
                    if (bettedIssueList.Contains(issueInfo.IssueNo))
                    {
                        Thread.Sleep(issueInfo.RemainTime);
                        continue;
                    }

                    if (issueInfo.RemainTime.TotalSeconds < 90)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{issueInfo.IssueNo}]期[服务端]距离封盘仅剩[{issueInfo.RemainTime.TotalSeconds}]秒，跳过投注", SourceEnum.Server, task.ServerUserName);
                        Thread.Sleep(issueInfo.RemainTime);
                        continue;
                    }

                    if (TeslaHelper.SkipIssue())
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{issueInfo.IssueNo}]期[服务端]跳过投注", SourceEnum.Server, task.ServerUserName);
                        Thread.Sleep(issueInfo.RemainTime);
                        continue;
                    }

                    if (BetParamApp.Exist())
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.WARN, $"客户端第[{Convert.ToInt32(issueInfo.IssueNo) - 1}]期未投注或投注失败，服务端当前期数：{issueInfo.IssueNo}", SourceEnum.Server, task.ServerUserName);
                        Thread.Sleep(issueInfo.RemainTime);
                        continue;
                    }

                    //是否需要重新登录
                    if (TeslaHelper.NeedReLogin(task, this._loginResponse, SourceEnum.Server))
                    {
                        ApiResponse<LoginResponse> newLogin = this.Login(task);
                        if (newLogin.IsSucceed)
                        {
                            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[服务端]任务信息变更，重新登录成功。期号：{issueInfo.IssueNo}", SourceEnum.Server, task.ServerUserName);
                            this._loginResponse = newLogin.data;
                        }
                        else
                        {
                            TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
                            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[服务端]任务信息变更，重新登录失败，已将：{task.Name}停止。期号：{issueInfo.IssueNo}", SourceEnum.Server, task.ServerUserName);
                            continue;
                        }
                    }

                    int seconds = RandomHelper.GetInstance().Next(15, 40);
                    Thread.Sleep(seconds * 1000);

                    bool isBet = this.Bet(task, issueInfo.IssueNo);
                    if (isBet)
                    {
                        bettedIssueList.Add(issueInfo.IssueNo);
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[服务端]投注异常。详情：{ex.ToString()}", SourceEnum.Server, task.ServerUserName);
                }
            }
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        /// <param name="issueNo"></param>
        /// <returns></returns>
        private bool Bet(AppTask task, string issueNo)
        {
            int numCount = RandomHelper.GetInstance().Next(task.ServerMinNumCount, task.ServerMaxNumCount + 1);
            List<string> fiftyNumList = BetHelper.GetBetInfo(numCount);

            BetParams betParam = BetHelper.GetBetParams(this._loginResponse, fiftyNumList, task.SingleMoney);
            betParam.Api = task.ServerApi;
            betParam.Issue = issueNo;
            betParam.IP = task.ServerIP;

            ApiResponse<BetResponse> response = BetHelper.Bet(betParam);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"第[{issueNo}]期[服务端]投注失败。信息：" + response.msg, SourceEnum.Server, task.ServerUserName);
                if (response.msg.Contains("余额"))
                {
                    TeslaHelper.StopTask(task.ID, TaskStopReason.ServerMoney);
                }
                else if (response.msg.ToLower().Contains("token"))
                {
                    ApiResponse<LoginResponse> newLogin = this.Login(task);
                    if (newLogin.IsSucceed)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"当前用户已掉线，已经重新登录", SourceEnum.Server, task.ServerUserName);
                        this._loginResponse = newLogin.data;
                    }
                    else
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"当前用户已掉线，重新登录失败，需要将任务：{task.Name}停止", SourceEnum.Server, task.ServerUserName);
                        TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
                    }
                }
            }
            else
            {
                List<string> fortyNumList = BetHelper.LHCNumberList.Except(fiftyNumList).ToList();
                decimal fortyMoney = fortyNumList.Count * task.SingleMoney;

                BetParams betParam2 = BetHelper.GetBetParams(this._loginResponse, fortyNumList, task.SingleMoney);
                betParam2.Issue = issueNo;
                betParam2.NumList = fortyNumList;

                this.SaveBetParam(task, betParam2);

                /* TODO:使用Mysql轮训方式投注
                int loops = 10;
                int index = 1;
                while (index < loops)
                {
                    try
                    {
                        RabbitMQHelper.Publish(MQConfig.BetExchange, "topic", "", betParam2);
                        break;
                    }
                    catch (Exception ex)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"推送投注信息异常。投注信息：{betParam.ToJson()}。异常：{ex.ToString()}", SourceEnum.Server);
                        index++;
                        Thread.Sleep(1000);
                    }
                }
                */

                decimal serverBalance = TeslaHelper.GetBalance(task.ServerApi, task.ServerIP, this._loginResponse);
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{issueNo}]期[服务端]投注成功。投注总额：{fiftyNumList.Count * task.SingleMoney}。", SourceEnum.Server, task.ServerUserName);
                TeslaHelper.SaveBetOrder(task, fiftyNumList, issueNo, serverBalance, SourceEnum.Server);
            }
            return true;
        }

        /// <summary>
        /// 保存投注参数
        /// </summary>
        /// <param name="betParam2"></param>
        private void SaveBetParam(AppTask task, BetParams betParam)
        {
            AppBetParam model = new AppBetParam
            {
                CreateTime = DateTime.Now,
                TaskId = task.ID,
                TaskName = task.Name,
                Params = betParam.ToJson()
            };

            int result = BetParamApp.Insert(model);
            if (result < 0)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"保存投注参数到数据库失败。参数：{model.ToJson()}", SourceEnum.Server, task.ServerUserName);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private ApiResponse<LoginResponse> Login(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.ServerUserName,
                Password = task.ServerUserPwd,
                Api = task.ServerApi,
                PlatformId = TeslaHelper.GetPlatformId(task.ServerCode),
                ClientType = task.ServerDeviceType,
                IP = task.ServerIP
            };

            int loops = 10, index = 0;
            ApiResponse<LoginResponse> response = null;
            while (index < loops)
            {
                try
                {
                    response = LoginHelper.Login(param);
                    break;
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户登录异常。详情：{ex.ToString()}", SourceEnum.Server, task.ServerUserName);
                    index++;
                    Thread.Sleep(10 * 1000);
                }
            }

            if (response == null)
            {
                response = new ApiResponse<LoginResponse> { msg = "登录失败", code = -1 };
            }

            return response;
        }
    }
}
