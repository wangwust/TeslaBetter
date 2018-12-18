using System;

namespace Tesla.Model
{
    /// <summary>
    /// AppBetInfo
    /// </summary>
    public class AppBetInfo
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public int LotteryID { get; set; }
        public decimal Money { get; set; }
        public int PlayId { get; set; }
        public int State { get; set; }
    }
}
