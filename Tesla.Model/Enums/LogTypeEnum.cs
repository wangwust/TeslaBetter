namespace Tesla.Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public static class LogTypeEnum
    {
        /// <summary>
        /// INFO
        /// </summary>
        public const string INFO = "INFO";

        /// <summary>
        /// DEBUG
        /// </summary>
        public const string DEBUG = "DEBUG";

        /// <summary>
        /// WARN
        /// </summary>
        public const string WARN = "WARN";

        /// <summary>
        /// ERROR
        /// </summary>
        public const string ERROR = "ERROR";

        /// <summary>
        /// FATAL
        /// </summary>
        public const string FATAL = "FATAL";

        /// <summary>
        /// 类型对应的中文
        /// </summary>
        /// <param name="logType"></param>
        /// <returns></returns>
        public static string LogText(this string logType)
        {
            switch (logType)
            {
                case LogTypeEnum.DEBUG: return "调试";
                case LogTypeEnum.ERROR: return "错误";
                case LogTypeEnum.FATAL: return "致命";
                case LogTypeEnum.INFO: return "信息";
                case LogTypeEnum.WARN: return "警告";
                default: return "其他";
            }
        }
    }
}
