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
        /// 每天几点开始执行
        /// </summary>
        public int StartHour { get; set; }

        /// <summary>
        /// 每天几点结束执行
        /// </summary>
        public int EndHour { get; set; }

        /// <summary>
        /// 单注金额
        /// </summary>
        //public decimal SingleMoney { get; set; }

        /// <summary>
        /// 平台代码
        /// </summary>
        public string PlatformCode { get; set; }

        /// <summary>
        /// 接口
        /// </summary>
        public string PlatformApi { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 连续亏损多少局就不再翻倍
        /// </summary>
        //public int MaxFailedCount { get; set; }

        /// <summary>
        /// 长龙期数下限
        /// </summary>
        //public int MinLongQueueCount { get; set; }

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
                    case 1: return "掉线";
                    case 2: return "余额不足";
                    case 3: return "手动停止";
                    default:return "未知";
                }
            }
        }

        /// <summary>
        /// SC状态
        /// </summary>
        public int SCState { get; set; }

        /// <summary>
        /// FT状态
        /// </summary>
        public int FTState { get; set; }

        /// <summary>
        /// 任务状态
        /// </summary>
        public int State { get; set; }
    }
}
