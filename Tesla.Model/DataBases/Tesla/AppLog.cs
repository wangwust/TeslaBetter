using Tesla.Utils;
using System;

namespace Tesla.Model
{
    /// <summary>
    /// 应用程序日志
    /// </summary>
    public class AppLog
    {
        /// <summary>
        /// ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 创建时间戳
        /// </summary>
        public long CreateTimestamp
        {
            get
            {
                return this.CreateTime.ToTimestamp();
            }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public int Source { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string SourceTxt => this.Source == SourceEnum.Server ? "服务端" : "客户端";

        /// <summary>
        /// 日志类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 日志类型文本
        /// </summary>
        public string TypeText => this.Type.LogText();

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 短消息
        /// </summary>
        public string ShortMsg
        {
            get
            {
                return Message.Length > 100 ? Message.Substring(0, 100) + "..." : Message;
            }
        }
    }
}
