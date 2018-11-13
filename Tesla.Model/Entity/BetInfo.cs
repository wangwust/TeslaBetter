namespace Tesla.Model
{
    /// <summary>
    /// 投注信息
    /// </summary>
    public class BetInfo
    {
        /// <summary>
        /// 投注金额
        /// </summary>
        public decimal money { get; set; }

        /// <summary>
        /// 投注号码
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// 玩法
        /// </summary>
        public long playId => 858549 + Number;
    }
}
