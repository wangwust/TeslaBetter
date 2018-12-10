using System;

namespace Tesla.Model
{
    /// <summary>
    /// 玩法
    /// </summary>
    public class GamePlay
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int LotteryID { get; set; }
        public long PlayID { get; set; }
        public string Remark { get; set; }

        /// <summary>
        /// 跟了多少期了
        /// </summary>
        public int LongQueue { get; set; }
    }
}
