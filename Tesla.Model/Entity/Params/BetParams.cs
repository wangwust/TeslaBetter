using System.Collections.Generic;

namespace Tesla.Model
{
    /// <summary>
    /// 投注参数
    /// </summary>
    public class BetParams : BaseParams
    {
        /// <summary>
        /// 投注内容
        /// </summary>
        public string BetInfo { get; set; }

        /// <summary>
        /// 投注期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 号码列表
        /// </summary>
        public List<string> NumList { get; set; }
    }
}
