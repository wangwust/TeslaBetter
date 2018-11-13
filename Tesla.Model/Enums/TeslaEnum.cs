using System;
using Tesla.Utils;

namespace Tesla.Model
{
    /// <summary>
    /// 常用的枚举
    /// </summary>
    public static class TeslaEnum
    {
        /// <summary>
        /// 账号密码
        /// </summary>
        public static string Account => ConfigHelper.AppSettings("Account");

        /// <summary>
        /// 号码个数上限
        /// </summary>
        public static int MaxCount => Convert.ToInt32(ConfigHelper.AppSettings("MaxCount"));

        /// <summary>
        /// 号码个数下限
        /// </summary>
        public static int MinCount => Convert.ToInt32(ConfigHelper.AppSettings("MinCount"));

        /// <summary>
        /// 单注
        /// </summary>
        public static int SingleMoney => Convert.ToInt32(ConfigHelper.AppSettings("SingleMoney"));

        /// <summary>
        /// 平台Id
        /// </summary>
        //public static string PlatformId => TeslaHelper.GetPlatformId(ConfigHelper.AppSettings("PlatformCode"));

        /// <summary>
        /// 客户端名称
        /// </summary>
        public static string ClientType => ConfigHelper.AppSettings("ClientType");
    }
}
