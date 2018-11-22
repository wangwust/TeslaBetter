using System;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Model
{
    /// <summary>
    /// AppLogParam
    /// </summary>
    public class AppLogParam
    {
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QuerySql
        {
            get
            {
                string sql = "1=1 ";
                if (!string.IsNullOrEmpty(this.Source))
                {
                    sql += "and Source = {0} ".Fmt(Source);
                }

                if (!string.IsNullOrEmpty(this.Type))
                {
                    sql += "and Type = '{0}' ".Fmt(Type);
                }

                if (!string.IsNullOrEmpty(StartTime))
                {
                    sql += "and CreateTimestamp >= {0} ".Fmt(Convert.ToDateTime(StartTime).ToTimestamp());
                }

                if (!string.IsNullOrEmpty(EndTime))
                {
                    sql += "and CreateTimestamp <= {0} ".Fmt(Convert.ToDateTime(EndTime).ToTimestamp());
                }

                if (!string.IsNullOrEmpty(Message))
                {
                    sql += "and Message like '%{0}%' ".Fmt(Message);
                }

                return sql;
            }
        }
    }
}