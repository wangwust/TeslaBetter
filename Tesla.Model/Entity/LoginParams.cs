namespace Tesla.Model
{
    /// <summary>
    /// 登录参数
    /// </summary>
    public class LoginParams
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string LoginApi { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string ClientType { get; set; }
    }
}
