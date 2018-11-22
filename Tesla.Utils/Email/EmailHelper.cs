using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Utils
{
    /// <summary>
    /// 邮件
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 同步发送邮件
        /// </summary>
        /// <param name="to">收件人邮箱地址</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        /// <param name="encoding">编码</param>
        /// <param name="isBodyHtml">是否Html</param>
        /// <param name="enableSsl">是否SSL加密连接</param>
        /// <returns>是否成功</returns>
        public static bool Send(string to, string subject, string body, string encoding = "UTF-8", bool isBodyHtml = true, bool enableSsl = false)
        {
            try
            {
                MailMessage message = new MailMessage();

                // 接收人邮箱地址
                message.To.Add(new MailAddress(to));
                message.From = new MailAddress(EmailSender.MailUserName, EmailSender.MailName);
                message.BodyEncoding = Encoding.GetEncoding(encoding);
                message.Body = body;

                //GB2312
                message.SubjectEncoding = Encoding.GetEncoding(encoding);
                message.Subject = subject;
                message.IsBodyHtml = isBodyHtml;

                SmtpClient smtpclient = new SmtpClient(EmailSender.MailServer, 25);
                smtpclient.Credentials = new NetworkCredential(EmailSender.MailUserName, EmailSender.MailPassword);

                //SSL连接
                smtpclient.EnableSsl = enableSsl;
                smtpclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 异步发送邮件 独立线程
        /// </summary>
        /// <param name="to">邮件接收人</param>
        /// <param name="title">邮件标题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="port">端口号</param>
        /// <returns></returns>
        public async static Task SendAsync(string to, string title, string body, int port = 25)
        {
            await Task.Run(() =>
            {
                try
                {
                    SmtpClient smtp = new SmtpClient();
                    //邮箱的smtp地址
                    smtp.Host = EmailSender.MailServer;
                    //端口号
                    smtp.Port = port;
                    //构建发件人的身份凭据类
                    smtp.Credentials = new NetworkCredential(EmailSender.MailUserName, EmailSender.MailPassword);
                    //构建消息类
                    MailMessage objMailMessage = new MailMessage();
                    //设置优先级
                    objMailMessage.Priority = MailPriority.High;
                    //消息发送人
                    objMailMessage.From = new MailAddress(EmailSender.MailUserName, EmailSender.MailName, Encoding.UTF8);
                    //收件人
                    objMailMessage.To.Add(to);
                    //标题
                    objMailMessage.Subject = title.Trim();
                    //标题字符编码
                    objMailMessage.SubjectEncoding = Encoding.UTF8;
                    //正文
                    objMailMessage.Body = body.Trim();
                    objMailMessage.IsBodyHtml = true;
                    //内容字符编码
                    objMailMessage.BodyEncoding = Encoding.UTF8;
                    //发送
                    smtp.Send(objMailMessage);
                }
                catch (Exception ex)
                {
                    throw;
                }
            });
        }
    }
}

