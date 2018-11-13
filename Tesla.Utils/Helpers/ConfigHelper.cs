using System.Configuration;

namespace Tesla.Utils
{
    /// <summary>
    /// 配置文件Helper
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string ConnectionStrings(string key)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[key].ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 配置项
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string AppSettings(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return "";
            }
        }
    }
}
