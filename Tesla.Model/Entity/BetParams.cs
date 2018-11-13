using System.Collections.Generic;

namespace Tesla.Model
{
    /// <summary>
    /// 投注参数
    /// </summary>
    public class BetParams
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 投注Api
        /// </summary>
        public string BetApi { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }

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
