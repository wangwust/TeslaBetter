namespace Tesla.Model
{
    /// <summary>
    /// 基础参数
    /// </summary>
    public class BaseParams
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 请求地址
        /// </summary>
        public string Api { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public string ClientType { get; set; }

        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 平台ID
        /// </summary>
        public string PlatformId { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }
    }
}
