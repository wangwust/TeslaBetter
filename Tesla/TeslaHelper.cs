using System;
using System.Collections.Generic;
using System.Linq;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// 特斯拉帮助类
    /// </summary>
    public static class TeslaHelper
    {
        /// <summary>
        /// 获取平台id
        /// </summary>
        /// <param name="platformCode"></param>
        /// <returns></returns>
        public static string GetPlatformId(string platformCode)
        {
            switch (platformCode.ToLower())
            {
                case "dd": return "08F22DF8F31643C78ADB8DC135E6DC92";
                case "ylc": return "7B9236017A4D4B26A43724D4D0F65C34";
                case "v8": return "7DFBB93AE9C5479786E7C303B4E6137F";
                case "k8": return "79B57E47C2d84629AC57A7A0F5825F23";
                case "cxc": return "CXD016C04EF149938F564A2EF03FF37C";
                default: throw new Exception($"非法的平台名称{platformCode}");
            }
        }

        /// <summary>
        /// 是否跳过当期
        /// </summary>
        /// <returns></returns>
        public static bool SkipIssue()
        {
            return RandomHelper.GetInstance().Next(1, 5) == 3;
        }

        /// <summary>
        /// 更新任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static AppTask Update(this AppTask task)
        {
            return TaskApp.GetOne(task.ID);
        }

        /// <summary>
        /// 校验任务
        /// </summary>
        /// <param name="appTask"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        public static bool CheckTaskParam(AppTask appTask, ref string errorMsg)
        {
            if (appTask == null)
            {
                errorMsg = "任务不能为null";
                return false;
            }

            if (appTask.State != 1)
            {
                errorMsg = $"任务{appTask.Name}未启动";
                return false;
            }

            if (appTask.ServerCode.IsEmpty())
            {
                errorMsg = "服务端代码不能为空";
                return false;
            }

            if (appTask.ServerApi.IsEmpty())
            {
                errorMsg = "服务端Api不能为空";
                return false;
            }

            if (appTask.ServerUserName.IsEmpty())
            {
                errorMsg = "服务端用户名不能为空";
                return false;
            }

            if (appTask.ServerUserPwd.IsEmpty())
            {
                errorMsg = "服务端用户密码不能为空";
                return false;
            }

            if (appTask.ServerDeviceType.IsEmpty())
            {
                errorMsg = "服务端设备类型不能为空";
                return false;
            }

            if (appTask.ClientCode.IsEmpty())
            {
                errorMsg = "客户端代码不能为空";
                return false;
            }

            if (appTask.ClientApi.IsEmpty())
            {
                errorMsg = "客户端Api不能为空";
                return false;
            }

            if (appTask.ClientUserName.IsEmpty())
            {
                errorMsg = "客户端用户名不能为空";
                return false;
            }

            if (appTask.ClientUserPwd.IsEmpty())
            {
                errorMsg = "客户端用户密码不能为空";
                return false;
            }

            if (appTask.ClientDeviceType.IsEmpty())
            {
                errorMsg = "客户端设备类型不能为空";
                return false;
            }

            if (appTask.SingleMoney <= 0)
            {
                errorMsg = "单注金额不合法";
                return false;
            }

            if (appTask.ServerMinNumCount > 49 || appTask.ServerMinNumCount < 1)
            {
                errorMsg = "服务端投注的号码个数下限不合法";
                return false;
            }

            if (appTask.ServerMaxNumCount > 49 || appTask.ServerMaxNumCount < 1)
            {
                errorMsg = "服务端投注的号码个数上限不合法";
                return false;
            }

            if (appTask.ServerMaxNumCount < appTask.ServerMinNumCount)
            {
                errorMsg = "服务端投注的号码个数上限不能小于下限";
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        /// <returns></returns>
        public static decimal GetBalance(string api, LoginResponse loginResponse)
        {
            if (loginResponse == null || string.IsNullOrEmpty(loginResponse.token))
            {
                return 0;
            }

            BalanceParams param = new BalanceParams
            {
                UserName = loginResponse.userName,
                Token = loginResponse.token,
                PlatformId = loginResponse.companyPlatformID,
                BalanceApi = api
            };

            ApiResponse<BalanceResponse> response = BalanceHelper.GetBalance(param);
            if (response.IsSucceed)
            {
                return response.data.accountBalance;
            }

            return 0;
        }

        /// <summary>
        /// 获取客户端余额
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static decimal GetClientBalance(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.ClientUserName,
                Password = task.ClientUserPwd,
                LoginApi = task.ClientApi,
                PlatformId = GetPlatformId(task.ClientCode),
                ClientType = task.ClientDeviceType
            };

            int loops = 10, index = 0;
            while (index < loops)
            {
                try
                {
                    ApiResponse<LoginResponse> response = LoginHelper.Login(param);
                    if (response.IsSucceed)
                    {
                        return GetBalance(task.ClientApi, response.data);
                    }
                    else
                    {
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户登录异常。详情：{ex.ToString()}", SourceEnum.Client, task.ClientUserName);
                    index++;
                }
            }

            return 0;
        }

        /// <summary>
        /// 获取服务端余额
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static decimal GetServerBalance(AppTask task)
        {
            LoginParams param = new LoginParams
            {
                UserName = task.ServerUserName,
                Password = task.ServerUserPwd,
                LoginApi = task.ServerApi,
                PlatformId = GetPlatformId(task.ServerCode),
                ClientType = task.ServerDeviceType
            };

            int loops = 10, index = 0;
            while (index < loops)
            {
                try
                {
                    ApiResponse<LoginResponse> response = LoginHelper.Login(param);
                    if (response.IsSucceed)
                    {
                        return GetBalance(task.ServerApi, response.data);
                    }
                    else
                    {
                        index++;
                    }
                }
                catch (Exception ex)
                {
                    TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"用户登录异常。详情：{ex.ToString()}", SourceEnum.Server, task.ServerUserName);
                    index++;
                }
            }

            return 0;
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="logType"></param>
        /// <param name="message"></param>
        /// <param name="source"></param>
        public static void WriteLog(int taskId, string taskName, string logType, string message, int source, string userName)
        {
            AppLog log = new AppLog
            {
                CreateTime = DateTime.Now,
                TaskId = taskId,
                TaskName = taskName,
                Source = source,
                Type = logType,
                Message = message,
                UserName = userName
            };

            int result = AppLogApp.Insert(log);

            if (result < 0)
            {
                Log4NetHelper.Error(typeof(TeslaHelper), $"保存日志到数据库失败。日志内容：{log.ToJson()}");
            }
        }

        /// <summary>
        /// 保存注单
        /// </summary>
        /// <param name="task"></param>
        /// <param name="fiftyNumList"></param>
        /// <param name="issueNo"></param>
        public static void SaveBetOrder(AppTask task, List<string> numList, string issueNo, decimal balance, int source)
        {
            List<int> list = (from s in numList select Convert.ToInt32(s)).ToList();
            list.Sort();

            BetOrder order = new BetOrder
            {
                CreateTime = DateTime.Now,
                TaskId = task.ID,
                TaskName = task.Name,
                Issue = Convert.ToInt64(issueNo),
                Number = list.Aggregate(string.Empty, (c, r) => c + r + ",").TrimEnd(','),
                SingleMoney = task.SingleMoney,
                TotalMoney = task.SingleMoney * list.Count,
                Source = source,
                BeforeBalance = balance,
                AfterBalance = balance - task.SingleMoney * list.Count,
                UserName = source == 1 ? task.ServerUserName : task.ClientUserName
            };

            int result = BetOrderApp.Insert(order);
            if (result < 0)
            {
                TeslaHelper.WriteLog(task.ID, task.Name, LogTypeEnum.ERROR, $"保存注单失败。注单：{order.ToJson()}", SourceEnum.Server, order.UserName);
            }
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="task"></param>
        public static void StopTask(int taskId, int stopReason)
        {
            AppTask task = new AppTask { ID = taskId, LastStopReason = stopReason, State = 0 };
            int result = TaskApp.UpdateState(task);
            if (result < 0)
            {
                Log4NetHelper.Error(typeof(TeslaHelper), $"停止任务失败。任务：{task.ToJson()}");
            }
        }

        /// <summary>
        /// 是否需要重新登录
        /// </summary>
        /// <param name="task"></param>
        /// <param name="loginResponse"></param>
        /// <returns></returns>
        public static bool NeedReLogin(AppTask task, LoginResponse loginResponse, int source)
        {
            string userName = source == SourceEnum.Server ? task.ServerUserName : task.ClientUserName;
            string platformId = source == SourceEnum.Server ? GetPlatformId(task.ServerCode) : GetPlatformId(task.ClientCode);

            return userName != loginResponse.userName || platformId != loginResponse.companyPlatformID;
        }
    }
}
