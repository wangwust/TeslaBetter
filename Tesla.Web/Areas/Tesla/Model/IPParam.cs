using Tesla.Utils;

namespace Tesla.Web
{
    /// <summary>
    /// IPParam
    /// </summary>
    public class IPParam
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// IP整型
        /// </summary>
        public long IPLong => IPHelper.IPToLong(this.IP);

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QuerySql
        {
            get
            {
                string sql = "1=1 ";
                if (!string.IsNullOrEmpty(this.Area))
                {
                    sql += "and Area like '%{0}%' ".Fmt(Area);
                }

                if (!string.IsNullOrEmpty(IP))
                {
                    sql += "and StartIP2 <= {0} and EndIP2 >= {0} ".Fmt(IPLong);
                }

                return sql;
            }
        }
    }
}