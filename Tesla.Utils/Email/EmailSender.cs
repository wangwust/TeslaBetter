namespace Tesla.Utils
{
    /// <summary>
    /// 邮件发送者
    /// </summary>
    public class EmailSender
    {
        /// <summary>
        /// 邮件服务器地址
        /// </summary>
        public static string MailServer => ConfigHelper.AppSettings("MailServer");

        /// <summary>
        /// 用户名
        /// </summary>
        public static string MailUserName => ConfigHelper.AppSettings("MailUserName");

        /// <summary>
        /// 密码
        /// </summary>
        public static string MailPassword => ConfigHelper.AppSettings("MailPassword");

        /// <summary>
        /// 名称
        /// </summary>
        public static string MailName => ConfigHelper.AppSettings("MailName");
    }
}
