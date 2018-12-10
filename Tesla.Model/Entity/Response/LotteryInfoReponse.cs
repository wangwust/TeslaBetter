using System;

namespace Tesla.Model
{
    /// <summary>
    /// 彩种信息
    /// </summary>
    public class LotteryInfoReponse
    {
        public LotteryInfo lotteryInfo { get; set; }
    }

    public class LotteryInfo
    {
        /// <summary>
        /// 当前期号
        /// </summary>
        public string curPeriodNum { get; set; }

        public long remainTime { get; set; }

        public int lotteryId { get; set; }

        public int blockTime { get; set; }

        public string lotteryName { get; set; }

        public long sysTime { get; set; }

        public OpenResult openResult { get; set; }

        public string menuDetails { get; set; }

        public string isHot { get; set; }

        public DateTime nextTime { get; set; }
    }

    /// <summary>
    /// 开奖结果
    /// </summary>
    public class OpenResult
    {
        public string openPeriod { get; set; }

        public string opencode { get; set; }

        public string opentime { get; set; }

        public string opentimestamp { get; set; }

        public string resultColor { get; set; }

        public string zodiac { get; set; }
    }
}
