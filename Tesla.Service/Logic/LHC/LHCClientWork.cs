﻿using System;
using System.Threading;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Service
{
    /// <summary>
    /// LHCClientWork
    /// </summary>
    public class LHCClientWork
    {
        private LoginResponse _loginResponse;

        /// <summary>
        /// 开始执行
        /// </summary>
        public void Start()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[客户端]已经启动", SourceEnum.Client, "");
            try
            {
                this.Run();
            }
            catch (Exception ex)
            {
                TeslaHelper.WriteLog(0, "", LogTypeEnum.ERROR, $"[客户端]执行异常：{ex.ToString()}", SourceEnum.Client, "");
            }
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[客户端]已经停止", SourceEnum.Client, "");
        }

        /// <summary>
        /// 开始执行
        /// </summary>
        private void Run()
        {
            //AppTask appTask = TaskApp.GetOne();
            //if (appTask == null)
            //{
            //    TeslaHelper.WriteLog(0, "", LogTypeEnum.WARN, "[客户端]没有可执行的任务", SourceEnum.Client, "");
            //    return;
            //}

            //string errorMsg = string.Empty;
            //if (!TeslaHelper.CheckTaskParam(appTask, ref errorMsg))
            //{
            //    TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, errorMsg, SourceEnum.Client, "");
            //    return;
            //}

            //TeslaHelper.WriteLog(0, "", LogTypeEnum.INFO, $"[客户端]开始执行任务：{appTask.Name}", SourceEnum.Client, "");
            //ApiResponse<LoginResponse> response = this.Login(appTask);
            //if (!response.IsSucceed)
            //{
            //    TeslaHelper.WriteLog(appTask.ID, appTask.Name, LogTypeEnum.ERROR, $"[客户端]DL失败。信息" + response.msg, SourceEnum.Client, appTask.ClientUserName);
            //    return;
            //}

            //this._loginResponse = response.data;
            //this.BetByMysql(appTask);
        }

        ///// <summary>
        ///// 使用mysql轮询获取TZ参数
        ///// </summary>
        ///// <param name="task"></param>
        ///// <param name="loginResponse"></param>
        //private void BetByMysql(AppTask task)
        //{
        //    while (true)
        //    {
        //        try
        //        {
        //            task = task.Update();
        //            string errorMsg = string.Empty;
        //            if (!TeslaHelper.CheckTaskParam(task, ref errorMsg))
        //            {
        //                Thread.Sleep(10 * 1000);
        //                continue;
        //            }

        //            //是否需要重新DL
        //            if (TeslaHelper.NeedReLogin(task, this._loginResponse, SourceEnum.Client))
        //            {
        //                ApiResponse<LoginResponse> newLogin = this.Login(task);
        //                if (newLogin.IsSucceed)
        //                {
        //                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]任务信息变更，重新DL成功。", SourceEnum.Client, task.ClientUserName);
        //                    this._loginResponse = newLogin.data;
        //                }
        //                else
        //                {
        //                    TeslaHelper.StopTask(task.ID, TaskStopReason.ServerToken);
        //                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]任务信息变更，重新DL失败，已将：{task.Name}停止。", SourceEnum.Client, task.ClientUserName);
        //                    continue;
        //                }
        //            }

        //            AppBetParam betParam = BetParamApp.GetOne();
        //            if (betParam == null)
        //            {
        //                Thread.Sleep(10 * 1000);
        //                continue;
        //            }

        //            BetParams param = betParam.BetParam;
        //            if (param == null)
        //            {
        //                this.DeleteBetParam(task, betParam);
        //                Thread.Sleep(10 * 1000);
        //                continue;
        //            }

        //            bool flag = this.Bet(task, param);
        //            if (flag)
        //            {
        //                this.DeleteBetParam(task, betParam);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[客户端]TZ异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);
        //        }
        //    }
        //}

        ///// <summary>
        ///// TZ
        ///// </summary>
        ///// <param name="param"></param>
        //private bool Bet(AppTask task, BetParams param)
        //{
        //    if (param == null)
        //    {
        //        return true;
        //    }

        //    if (string.IsNullOrEmpty(param.Issue) || string.IsNullOrEmpty(param.BetInfo))
        //    {
        //        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"[客户端]TZ失败。参数有误。实体：{param.ToJson()}", SourceEnum.Client, task.ClientUserName);
        //        return true;
        //    }

        //    param.UserName = this._loginResponse.userName;
        //    param.Token = this._loginResponse.token;
        //    param.PlatformId = TeslaHelper.GetPlatformId(task.ClientCode);
        //    param.Api = task.ClientApi;
        //    param.IP = task.ClientIP;

        //    try
        //    {
        //        ApiResponse<BetResponse> response = BetHelper.Bet(param);
        //        if (response.IsSucceed)
        //        {
        //            decimal clientBalance = TeslaHelper.GetBalance(task.ClientApi, task.ClientIP, this._loginResponse);
        //            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"第[{param.Issue}]期[客户端]TZ成功。TZ总额：{param.NumList.Count * task.SingleMoney}。", SourceEnum.Client, task.ClientUserName);
        //            TeslaHelper.SaveBetOrder(task, param.NumList, param.Issue, clientBalance, SourceEnum.Client);

        //            decimal balance = clientBalance;
        //            if (balance < task.SingleMoney * (49 - task.ServerMinNumCount))
        //            {
        //                TeslaHelper.StopTask(task.ID, TaskStopReason.ClientMoney);
        //                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]余额仅剩{balance}，不足下次TZ，已将任务停止。", SourceEnum.Client, task.ClientUserName);
        //            }

        //            return true;
        //        }

        //        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"第[{param.Issue}]期[客户端]TZ失败。信息：" + response.msg, SourceEnum.Client, task.ClientUserName);
        //        if (response.msg.Contains("余额"))
        //        {
        //            TeslaHelper.StopTask(task.ID, TaskStopReason.ClientMoney);
        //            return true;
        //        }

        //        if (response.msg.ToLower().Contains("token"))
        //        {
        //            ApiResponse<LoginResponse> newLogin = this.Login(task);
        //            if (newLogin.IsSucceed)
        //            {
        //                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]当前用户已掉线，已经重新DL", SourceEnum.Client, task.ClientUserName);
        //                this._loginResponse = newLogin.data;
        //                return false;
        //            }
        //            else
        //            {
        //                TeslaHelper.StopTask(task.ID, TaskStopReason.ClientToken);
        //                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.INFO, $"[客户端]当前用户已掉线，重新DL失败，已将任务：{task.Name}停止", SourceEnum.Client, task.ClientUserName);
        //                return true;
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// 删除TZ参数
        ///// </summary>
        ///// <param name="betParam"></param>
        //private void DeleteBetParam(AppTask task, AppBetParam betParam)
        //{
        //    int result = BetParamApp.Delete(betParam.ID);
        //    if (result < 0)
        //    {
        //        TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"删除TZ参数失败。实体：{betParam.ToJson()}", SourceEnum.Client, task.ClientUserName);
        //    }
        //}

        ///// <summary>
        ///// DL
        ///// </summary>
        ///// <param name="task"></param>
        ///// <returns></returns>
        //private ApiResponse<LoginResponse> Login(AppTask task)
        //{
        //    LoginParams param = new LoginParams
        //    {
        //        UserName = task.ClientUserName,
        //        Password = task.ClientUserPwd,
        //        Api = task.ClientApi,
        //        PlatformId = TeslaHelper.GetPlatformId(task.ClientCode),
        //        ClientType = task.ClientDeviceType,
        //        IP = task.ClientIP
        //    };

        //    int loops = 10, index = 0;
        //    ApiResponse<LoginResponse> response = null;
        //    while (index < loops)
        //    {
        //        try
        //        {
        //            response = LoginHelper.Login(param);
        //            if (response.IsSucceed)
        //            {
        //                break;
        //            }
        //            else
        //            {
        //                index++;
        //                Thread.Sleep(10 * 1000);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户DL异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);
        //            index++;
        //            Thread.Sleep(10 * 1000);
        //        }
        //    }

        //    if (response == null)
        //    {
        //        response = new ApiResponse<LoginResponse> { msg = "DL失败", code = -1 };
        //    }

        //    return response;
        //}
    }
}
