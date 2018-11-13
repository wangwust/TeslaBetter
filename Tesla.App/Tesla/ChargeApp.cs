using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.App
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public static class ChargeApp
    {
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(Charge model)
        {
            string sql = "insert into app_charge(CreateTime, Name, Way, Money) "
                       + "values(@CreateTime, @Name, @Way, @Money)";
            return DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = "update app_charge set IsDeleted = 1, UpdateTime=now() where ID=@id";
            return DBHelper.Execute(sql, new { id });
        }

        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="pageInfo"></param>
        /// <returns></returns>
        public static List<Charge> GetList(PagerInfo pageInfo)
        {
            return DBHelper.GetPageList<Charge>(pageInfo);
        }
    }
}
