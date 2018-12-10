namespace Tesla.Model
{
    /// <summary>
    /// 投注信息
    /// </summary>
    public class SCBetInfo
    {
        /// <summary>
        /// 投注金额
        /// </summary>
        public decimal money { get; set; }

        /// <summary>
        /// 玩法
        /// </summary>
        public long playId { get; set; }
    }
}
