using Tesla.Utils;

namespace Tesla.Model
{
    /// <summary>
    /// Api枚举
    /// </summary>
    public static class ApiEnum
    {
        /// <summary>
        /// API
        /// </summary>
        private static string Api => ConfigHelper.AppSettings("Api");

        /// <summary>
        /// 登录API
        /// </summary>
        public static string LoginApi => Api + "/user/login";

        /// <summary>
        /// 投注API
        /// </summary>
        public static string BetApi => Api + "/order/bet/85";

        /// <summary>
        /// 余额API
        /// </summary>
        public static string BalanceApi => Api + "/user/balance";
    }
}
