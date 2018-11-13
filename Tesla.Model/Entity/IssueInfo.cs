using System;

namespace Tesla.Model
{
    /// <summary>
    /// 期数
    /// </summary>
    public class IssueInfo
    {
        /// <summary>
        /// 当前期号
        /// </summary>
        public string IssueNo { get; set; }

        /// <summary>
        /// 距离采集剩余时间（秒）
        /// </summary>
        public TimeSpan RemainTime { get; set; }
    }
}
