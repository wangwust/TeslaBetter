namespace Tesla.Model
{
    /// <summary>
    /// RegisterResponse
    /// </summary>
    public class RegisterResponse
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
