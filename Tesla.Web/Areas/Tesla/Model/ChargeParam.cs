using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Model
{
    /// <summary>
    /// 充值参数
    /// </summary>
    public class ChargeParam
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 查询条件
        /// </summary>
        public string QuerySql
        {
            get
            {
                string sql = "IsDeleted=0 ";
                if (!string.IsNullOrEmpty(this.Name))
                {
                    sql += "and Name like '%{0}%' ".Fmt(Name);
                }

                return sql;
            }
        }
    }
}