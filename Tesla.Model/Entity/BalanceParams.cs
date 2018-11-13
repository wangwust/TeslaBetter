namespace Tesla.Model
{
    /// <summary>
    /// 余额请求参数
    /// </summary>
    public  class BalanceParams
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string BalanceApi { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }
    }
}
