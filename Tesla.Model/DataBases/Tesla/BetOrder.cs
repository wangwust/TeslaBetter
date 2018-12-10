using System;
using Tesla.Utils;

namespace Tesla.Model
{
    /// <summary>
    /// 投注记录
    /// </summary>
    public class BetOrder
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateTimestamp
        {
            get
            {
                return this.CreateTime.ToTimestamp();
            }
        }

        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 彩种名称
        /// </summary>
        public string LotteryName { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        public long Issue { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 单注金额
        /// </summary>
        public decimal SingleMoney { get; set; }

        /// <summary>
        /// 投注总额
        /// </summary>
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 投注前余额
        /// </summary>
        public decimal BeforeBalance { get; set; }

        /// <summary>
        /// 投注后余额
        /// </summary>
        public decimal AfterBalance { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string SourceTxt => this.Source == SourceEnum.Server ? "服务端" : "客户端";
    }
}
