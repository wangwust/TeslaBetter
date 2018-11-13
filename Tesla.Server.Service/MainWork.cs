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
        /// <summary>
        /// 开始执行
        /// </summary>
        public void Run()
        {
            Log4NetHelper.Info(typeof(MainWork), $"服务端已经启动");
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
        /// 执行
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
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Server, "");
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            Log4NetHelper.Info(typeof(MainWork), $"服务端开始执行任务：{appTask.Name}");
            ApiResponse<LoginReponse> response = this.Login(appTask);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, $"登录失败。信息" + response.msg, SourceEnum.Server, appTask.ServerUserName);
                Thread.Sleep(60 * 60 * 1000);
                return;
            }

            LoginReponse loginResponse = response.data;
            this.Bet(appTask, loginResponse);
        }

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        private void Bet(AppTask task, LoginReponse loginResponse)
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
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Server, task.ServerUserName);
                        Thread.Sleep(5 * 60 * 1000);
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

                    if (issueInfo.RemainTime.TotalSeconds < 60)
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
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.WARN, "客户端未投注或投注失败", SourceEnum.Server, task.ServerUserName);
                        Thread.Sleep(5 * 60 * 1000);
                        continue;
                    }

                    int seconds = RandomHelper.GetInstance().Next(15, 60);
                    Thread.Sleep(seconds * 1000);

                    int numCount = RandomHelper.GetInstance().Next(task.ServerMinNumCount, task.ServerMaxNumCount + 1);

                    decimal serverBalance = TeslaHelper.GetBalance(task.ServerApi, loginResponse);
                    //if (serverBalance < numCount * task.SingleMoney)
                    //{
                    //    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.WARN, $"第[{issueInfo.IssueNo}]期[服务端]无法投注，服务端余额不足。当前余额：{serverBalance}，投注总额：{numCount * task.SingleMoney}", SourceEnum.Server);
                    //    TeslaHelper.StopTask(task.ID, TaskStopReason.ServerMoney);
                    //    Thread.Sleep(60 * 1000);
                    //    continue;
                    //}

                    List<string> fiftyNumList = BetHelper.GetBetInfo(numCount);

                    BetParams betParam = BetHelper.GetBetParams(loginResponse, fiftyNumList, task.SingleMoney);
                    betParam.BetApi = task.ServerApi;
                    betParam.Issue = issueInfo.IssueNo;

                    ApiResponse<BetResponse> response = BetHelper.Bet(betParam);
                    if (!response.IsSucceed)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"第[{issueInfo.IssueNo}]期[服务端]投注失败。信息：" + response.msg, SourceEnum.Server, task.ServerUserName);
                        if (response.msg.Contains("余额"))
                        {
                            TeslaHelper.StopTask(task.ID, TaskStopReason.ServerMoney);
                            Thread.Sleep(60 * 1000);
                        }

                        if (response.msg.ToLower().Contains("token"))
                        {
                            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"用户已掉线，即将重新登录", SourceEnum.Server, task.ServerUserName);
                            ApiResponse<LoginReponse> newLogin = this.Login(task);
                            if (newLogin.IsSucceed)
                            {
                                loginResponse = newLogin.data;
                            }
                            else
                            {
                                TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
                                Thread.Sleep(60 * 1000);
                            }
                        }

                        continue;
                    }
                    else
                    {
                        bettedIssueList.Add(issueInfo.IssueNo);

                        List<string> fortyNumList = BetHelper.LHCNumberList.Except(fiftyNumList).ToList();
                        decimal fortyMoney = fortyNumList.Count * task.SingleMoney;

                        BetParams betParam2 = BetHelper.GetBetParams(loginResponse, fortyNumList, task.SingleMoney);
                        betParam2.Issue = issueInfo.IssueNo;
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

                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{issueInfo.IssueNo}]期[服务端]投注成功。投注总额：{fiftyNumList.Count * task.SingleMoney}。投注信息：{betParam.ToJson()}", SourceEnum.Server, task.ServerUserName);
                        TeslaHelper.SaveBetOrder(task, fiftyNumList, issueInfo.IssueNo, serverBalance, SourceEnum.Server);
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[服务端]投注异常。详情：{ex.ToString()}", SourceEnum.Server, task.ServerUserName);
                }
            }
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
        private ApiResponse<LoginReponse> Login(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.ServerUserName,
                Password = task.ServerUserPwd,
                LoginApi = task.ServerApi,
                PlatformId = TeslaHelper.GetPlatformId(task.ServerCode),
                ClientType = task.ServerDeviceType
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
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户登录异常。详情：{ex.ToString()}", SourceEnum.Server, task.ServerUserName);
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
