using System;

namespace Tesla.Model
{
    /// <summary>
    /// AppResult
    /// </summary>
    public class AppResult
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public int LotteryID { get; set; }
        public DateTime Date { get; set; }
        public int Rank { get; set; }
        public int SingleCount { get; set; }
        public int DoubleCount { get; set; }
        public int BigCount { get; set; }
        public int SmallCount { get; set; }
        public int LongCount { get; set; }
        public int HuCount { get; set; }
    }
}
