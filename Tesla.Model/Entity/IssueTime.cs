using System;

namespace Tesla.Model
{
    /// <summary>
    /// 开奖时间模型
    /// </summary>
    public class IssueTime
    {
        public int ID { get; set; }

        public int? LotteryID { get; set; }

        public string Issue { get; set; }

        public string BeginTime { get; set; }

        public string CloseTime { get; set; }

        public string EndTime { get; set; }

        public int? BeginUseDate { get; set; }

        public int? EndUseDate { get; set; }

        public DateTime? CreateTime { get; set; }
    }
}
