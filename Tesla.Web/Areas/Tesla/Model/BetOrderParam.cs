using System;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Model
{
    /// <summary>
    /// 注单搜索条件
    /// </summary>
    public class BetOrderParam
    {
        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 期号
        /// </summary>
        public string Issue { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndTime { get; set; }

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

                if (!string.IsNullOrEmpty(this.Issue))
                {
                    sql += "and Issue = {0} ".Fmt(Issue);
                }

                if (!string.IsNullOrEmpty(this.TaskName))
                {
                    sql += "and TaskName like '%{0}%' ".Fmt(TaskName);
                }

                if (!string.IsNullOrEmpty(StartTime))
                {
                    sql += "and CreateTimestamp >= {0} ".Fmt(Convert.ToDateTime(StartTime).ToTimestamp());
                }

                if (!string.IsNullOrEmpty(EndTime))
                {
                    sql += "and CreateTimestamp <= {0} ".Fmt(Convert.ToDateTime(EndTime).ToTimestamp());
                }

                return sql;
            }
        }
    }
}