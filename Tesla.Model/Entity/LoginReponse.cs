namespace Tesla.Model
{
    /// <summary>
    /// 登录响应
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal accountBalance { get; set; }

        /// <summary>
        /// 登录token
        /// </summary>
        public string token { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public string companyPlatformID { get; set; }
    }
}

