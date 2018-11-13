using System;

namespace Tesla.Model
{
    /// <summary>
    /// 任务
    /// </summary>
    public class AppTask
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单注金额
        /// </summary>
        public decimal SingleMoney { get; set; }

        /// <summary>
        /// 每天几点开始执行
        /// </summary>
        public int StartHour { get; set; }

        /// <summary>
        /// 每天几点结束执行
        /// </summary>
        public int EndHour { get; set; }

        /// <summary>
        /// 服务端平台代码
        /// </summary>
        public string ServerCode { get; set; }

        /// <summary>
        /// 服务端接口
        /// </summary>
        public string ServerApi { get; set; }

        /// <summary>
        /// 服务端用户名
        /// </summary>
        public string ServerUserName { get; set; }

        /// <summary>
        /// 服务端密码
        /// </summary>
        public string ServerUserPwd { get; set; }

        /// <summary>
        /// 服务端设备类型
        /// </summary>
        public string ServerDeviceType { get; set; }

        /// <summary>
        /// 服务端号码上限
        /// </summary>
        public int ServerMaxNumCount { get; set; }

        /// <summary>
        /// 服务端号码下限
        /// </summary>
        public int ServerMinNumCount { get; set; }

        /// <summary>
        /// 客户端平台代码
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// 客户端接口
        /// </summary>
        public string ClientApi { get; set; }

        /// <summary>
        /// 客户端用户名
        /// </summary>
        public string ClientUserName { get; set; }

        /// <summary>
        /// 客户端密码
        /// </summary>
        public string ClientUserPwd { get; set; }

        /// <summary>
        /// 客户端设备类型
        /// </summary>
        public string ClientDeviceType { get; set; }

        /// <summary>
        /// 上次停止的原因
        /// </summary>
        public int LastStopReason { get; set; }

        /// <summary>
        /// 上次停止原因
        /// </summary>
        public string LastStopReasonTxt
        {
            get
            {
                switch (this.LastStopReason)
                {
                    case 0: return "未启动";
                    case 1: return "服务端掉线";
                    case 2: return "服务端余额不足";
                    case 3: return "服务端投注异常";
                    case 4: return "客户端掉线";
                    case 5: return "客户端余额不足";
                    case 6: return "客户端投注异常";
                    case 7: return "手动停止";
                    default:return "未知";
                }
            }
        }

        /// <summary>
        /// 任务状态
        /// </summary>
        public int State { get; set; }
    }
}
