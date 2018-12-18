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

            Task.Run(() =>
            {
                this.Bet(appTask, LotteryEnum.SC);
            });

            Task.Run(() =>
            {
                this.Bet(appTask, LotteryEnum.FT);
            });
        }

        /// <summary>
        /// TZ
        /// </summary>
        /// <param name="task"></param>
        private void Bet(AppTask task, int lotteryId)
        {
            while (true)
            {
                try
                {
                    task = task.Update();

                    #region 1、BOOL
                    if (task.State != 1)
                    {
                        Thread.Sleep(10 * 1000);
                        continue;
                    }

                    if (DateTime.Now.Hour < task.StartHour || DateTime.Now.Hour > task.EndHour)
                    {
                        Thread.Sleep(60 * 60 * 1000);
                        continue;
                    }

                    if ((lotteryId == LotteryEnum.SC && task.SCState != 1) || (lotteryId == LotteryEnum.FT && task.FTState != 1))
                    {
                        Thread.Sleep(10 * 1000);
                        continue;
                    }
                    #endregion

                    #region 2、LotteryInfo
                    ApiResponse<LotteryInfoReponse> response = this.GetLotteryInfo(task, lotteryId);
                    if (!response.IsSucceed)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[{lotteryId}]获取LotteryInfo失败，原因：{response.msg}", SourceEnum.Server, task.UserName);
                        Thread.Sleep(5 * 1000);
                        continue;
                    }

                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    LotteryInfo lotteryInfo = response.data.lotteryInfo;

                    int remainSeconds = (int)(lotteryInfo.remainTime - lotteryInfo.sysTime);

                    //是否TZ过
                    if (TeslaHelper.IsExist(lotteryId, lotteryInfo.curPeriodNum))
                    {
                        if (remainSeconds > 0)
                        {
                            Thread.Sleep(remainSeconds * 1000);
                        }
                        continue;
                    }

                    int tzTime = remainSeconds - lotteryInfo.blockTime;
                    if (tzTime < 40)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[{lotteryInfo.lotteryId}]第[{lotteryInfo.curPeriodNum}]期，距离FP仅剩{tzTime}秒，跳过TZ", SourceEnum.Server, task.UserName);

                        if (remainSeconds > 0)
                        {
                            Thread.Sleep(remainSeconds * 1000);
                        }
                        continue;
                    }

                    if (Convert.ToInt64(lotteryInfo.curPeriodNum) - Convert.ToInt64(lotteryInfo.openResult.openPeriod) != 1)
                    {
                        Thread.Sleep(5 * 1000);
                        continue;
                    }
                    #endregion

                    #region 3、BetInfo
                    List<AppBetInfo> betInfoList = BetInfoApp.GetList(lotteryId);
                    if (betInfoList.Count == 0)
                    {
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"{lotteryId}：第{lotteryInfo.curPeriodNum}期跳过TZ，没有TZ信息。", SourceEnum.Server, task.Name);
                        Thread.Sleep(remainSeconds * 1000);
                        continue;
                    }
                    #endregion

                    #region 4、TZ
                    bool isBet = this.Bet(task, lotteryInfo, betInfoList);

                    stopWatch.Stop();
                    int tmpMiliSeconds = (int)(remainSeconds * 1000 - stopWatch.ElapsedMilliseconds);
                    if (tmpMiliSeconds > 0)
                    {
                        Thread.Sleep(tmpMiliSeconds);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[SC]TZ异常。详情：{ex.ToString()}", SourceEnum.Server, task.UserName);
                    Thread.Sleep(10 * 1000);
                }
            }
        }

        /// <summary>
        /// TZ
        /// </summary>
        /// <param name="task"></param>
        /// <param name="lotteryInfo"></param>
        /// <param name="betInfoList"></param>
        /// <returns></returns>
        private bool Bet(AppTask task, LotteryInfo lotteryInfo, List<AppBetInfo> betInfoList)
        {
            decimal totalMoney = 0; string cateName = "";
            BetParams betParam = SCBetHelper.GetBetParams(task, betInfoList, lotteryInfo.lotteryId, ref totalMoney, ref cateName);
            if (string.IsNullOrEmpty(betParam.BetInfo))
            {
                return true;
            }

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
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[{lotteryInfo.lotteryId}]第[{lotteryInfo.curPeriodNum}]期TZ失败。信息：" + response.msg, SourceEnum.Server, task.UserName);
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
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[{lotteryInfo.lotteryId}]第[{lotteryInfo.curPeriodNum}]期TZ成功。TZ总额：{totalMoney}", SourceEnum.Server, task.UserName);
                TeslaHelper.SaveBetOrder(task, totalMoney, lotteryInfo.curPeriodNum, serverBalance, cateName.TrimEnd(','), lotteryInfo.lotteryName);
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
                        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[SCBetter]用户DL成功，用户：{task.UserName}。当前YUE：{response.data.accountBalance}", SourceEnum.Server, task.UserName);
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


