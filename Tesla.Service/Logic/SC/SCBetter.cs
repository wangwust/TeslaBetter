using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Service
{
    /// <summary>
    /// SCBetter
    /// </summary>
    public class SCBetter
    {
        private LoginResponse _loginResponse;

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[SCBetter]已启动", SourceEnum.Server, "");
            try
            {
                this.Run();
            }
            catch (Exception ex)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.ERROR, $"[SCBetter]执行异常：{ex.ToString()}", SourceEnum.Server, "");
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[SCBetter]已停止", SourceEnum.Server, "");
        }

        /// <summary>
        /// 执行
        /// </summary>
        private void Run()
        {
            AppTask appTask = TaskApp.GetOne();
            if (appTask == null)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.WARN, "[SCBetter]没有可执行的任务", SourceEnum.Server, "");
                return;
            }

            string errorMsg = string.Empty;
            if (!TeslaHelper.CheckTaskParam(appTask, ref errorMsg))
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Server, "");
                return;
            }

            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[SCBetter]开始执行任务：{appTask.Name}", SourceEnum.Server, "");
            ApiResponse<LoginResponse> response = this.Login(appTask);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, $"[SCBetter]DL失败，用户名：{appTask.UserName}。信息" + response.msg, SourceEnum.Server, appTask.UserName);
                return;
            }

            this._loginResponse = response.data;
            Task.Run(() => { this.Bet(appTask, LotteryEnum.SC); });
            Task.Run(() => { this.Bet(appTask, LotteryEnum.FT); });
        }

        /// <summary>
        /// TZ
        /// </summary>
        /// <param name="task"></param>
        private void Bet(AppTask task, int lotteryId)
        {
            List<string> bettedIssueList = new List<string>();
            while (true)
            {
                try
                {
                    #region BOOL
                    if (DateTime.Now.Hour < task.StartHour || DateTime.Now.Hour > task.EndHour)
                    {
                        Thread.Sleep(60 * 60 * 1000);
                        continue;
                    }

                    if ((lotteryId == LotteryEnum.SC && task.SCState != 1) || (lotteryId == LotteryEnum.FT && task.FTState != 1))
                    {
                        Thread.Sleep(5 * 60 * 1000);
                        continue;
                    }
                    #endregion

                    #region LotteryInfo
                    ApiResponse<LotteryInfoReponse> response = this.GetLotteryInfo(task, lotteryId);
                    if (!response.IsSucceed)
                    {
                        Thread.Sleep(5 * 1000);
                        continue;
                    }

                    LotteryInfo lotteryInfo = response.data.lotteryInfo;
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    TimeSpan remainTime = lotteryInfo.nextTime - DateTime.Now;
                    if (remainTime.TotalSeconds - lotteryInfo.blockTime < 40 || bettedIssueList.Contains(lotteryInfo.curPeriodNum))
                    {
                        Thread.Sleep(remainTime);
                        continue;
                    }

                    //if (Convert.ToInt64(lotteryInfo.curPeriodNum) - Convert.ToInt64(lotteryInfo.openResult.openPeriod) != 1)
                    //{
                    //    Thread.Sleep(5 * 1000);
                    //    continue;
                    //}
                    #endregion

                    #region LongQueue
                    ApiResponse<LongQueueResponse> longQueueResponse = this.GetLongQueue(task, lotteryId);
                    if (!response.IsSucceed)
                    {
                        Thread.Sleep(5 * 1000);
                        continue;
                    }

                    LongQueue longQueue = longQueueResponse.data.LongQueueList.Where(o => o.Cont >= task.MinLongQueueCount).FirstOrDefault();
                    if (longQueue == null)
                    {
                        Thread.Sleep(remainTime);
                        continue;
                    }
                    #endregion

                    #region TZ
                    bool isBet = this.Bet(task, lotteryInfo, longQueue);
                    if (isBet)
                    {
                        bettedIssueList.Add(lotteryInfo.curPeriodNum);
                    }
                    stopWatch.Stop();
                    Thread.Sleep(remainTime - stopWatch.Elapsed);
                    #endregion
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[SC]TZ异常。详情：{ex.ToString()}", SourceEnum.Server, task.UserName);
                }
            }
        }

        /// <summary>
        /// TZ
        /// </summary>
        /// <param name="task"></param>
        /// <param name="lotteryInfo"></param>
        /// <param name="longQueue"></param>
        /// <returns></returns>
        private bool Bet(AppTask task, LotteryInfo lotteryInfo, LongQueue longQueue)
        {
            decimal totalMoney = 0; string cateName = "";
            BetParams betParam = SCBetHelper.GetBetParams(task, longQueue, task.SingleMoney, lotteryInfo.lotteryId, ref totalMoney, ref cateName);
            betParam.Token = this._loginResponse.token;
            betParam.UserName = this._loginResponse.userName;
            betParam.PlatformId = this._loginResponse.companyPlatformID;
            betParam.Api = task.PlatformApi;
            betParam.Issue = lotteryInfo.curPeriodNum;
            betParam.IP = task.IP;
            betParam.LotteryID = lotteryInfo.lotteryId;
            betParam.ClientType = task.DeviceType;

            ApiResponse<BetResponse> response = BetHelper.Bet(betParam);
            if (!response.IsSucceed)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"第[{lotteryInfo.curPeriodNum}]期[{lotteryInfo.lotteryId}]TZ失败。信息：" + response.msg, SourceEnum.Server, task.UserName);
                if (response.msg.Contains("余额"))
                {
                    TeslaHelper.StopTask(task.ID, TaskStopReason.ServerMoney);
                }
                else if (response.msg.ToLower().Contains("token"))
                {
                    ApiResponse<LoginResponse> newLogin = this.Login(task);
                    if (newLogin.IsSucceed)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"当前用户掉线，已经重新DL", SourceEnum.Server, task.Name);
                        this._loginResponse = newLogin.data;
                    }
                    else
                    {
                        TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"当前用户掉线，重新DL失败，已将任务：{task.Name}停止", SourceEnum.Server, task.UserName);
                    }
                }
            }
            else
            {
                decimal serverBalance = TeslaHelper.GetBalance(task.PlatformApi, task.IP, this._loginResponse);
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{lotteryInfo.curPeriodNum}]期[{lotteryInfo.lotteryId}]TZ成功。TZ总额：{totalMoney}", SourceEnum.Server, task.UserName);
                TeslaHelper.SaveBetOrder(task, totalMoney, lotteryInfo.curPeriodNum, serverBalance, cateName, lotteryInfo.lotteryName);
                TeslaHelper.UpdateLongQueue(task, longQueue, lotteryInfo.lotteryId);
            }
            return true;
        }

        /// <summary>
        /// DL
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private ApiResponse<LoginResponse> Login(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.UserName,
                Password = task.UserPwd,
                Api = task.PlatformApi,
                PlatformId = TeslaHelper.GetPlatformId(task.PlatformCode),
                ClientType = task.DeviceType,
                IP = task.IP
            };

            int loops = 10, index = 0;
            ApiResponse<LoginResponse> response = null;
            while (index < loops)
            {
                try
                {
                    response = LoginHelper.Login(param);
                    if (response.IsSucceed)
                    {
                        break;
                    }
                    else
                    {
                        index++;
                        Thread.Sleep(10 * 1000);
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[SCBetter]用户DL异常，用户：{task.UserName}。详情：{ex.ToString()}", SourceEnum.Server, task.UserName);
                    index++;
                    Thread.Sleep(10 * 1000);
                }
            }

            if (response == null)
            {
                response = new ApiResponse<LoginResponse> { msg = "DL失败", code = -1 };
            }

            return response;
        }

        /// <summary>
        /// GetLotteryInfo
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        private ApiResponse<LotteryInfoReponse> GetLotteryInfo(AppTask task, int lotteryId)
        {
            LotteryInfoParams param = new LotteryInfoParams
            {
                Api = task.PlatformApi,
                IP = task.IP,
                ClientType = task.DeviceType,
                PlatformId = TeslaHelper.GetPlatformId(task.PlatformCode),
                UserName = task.UserName,
                Token = this._loginResponse.token,
                LotteryID = lotteryId
            };

            return SCBetHelper.GetLotteryInfo(param);
        }

        /// <summary>
        /// GetLongQueue
        /// </summary>
        /// <param name="task"></param>
        /// <param name="lotteryId"></param>
        /// <returns></returns>
        private ApiResponse<LongQueueResponse> GetLongQueue(AppTask task, int lotteryId)
        {
            LongQueueParams param = new LongQueueParams
            {
                Api = task.PlatformApi,
                IP = task.IP,
                ClientType = task.DeviceType,
                PlatformId = TeslaHelper.GetPlatformId(task.PlatformCode),
                UserName = task.UserName,
                Token = this._loginResponse.token,
                LotteryID = lotteryId
            };

            return SCBetHelper.GetLongQueue(param);
        }
    }
}


