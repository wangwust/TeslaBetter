using System;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Model
{
    /// <summary>
    /// AppUserParam
    /// </summary>
    public class AppUserParam
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QuerySql
        {
            get
            {
                string sql = "1=1 ";
                if (!string.IsNullOrEmpty(this.UserName))
                {
                    sql += "and UserName like '%{0}%' ".Fmt(UserName);
                }

                return sql;
            }
        }

    }
}