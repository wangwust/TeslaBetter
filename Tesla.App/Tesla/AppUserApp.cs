using System.Collections.Generic;
using System.Linq;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.App
{
    /// <summary>
    /// AppUserApp
    /// </summary>
    public static class AppUserApp
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static List<AppUser> GetList(PagerInfo pagerInfo)
        {
            return DBHelper.GetPageList<AppUser>(pagerInfo).ToList();
        }

        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(AppUser model)
        {
            string sql = "insert into app_user(CreateTime, UserName, Password, RealName, CellPhone, WithdrawPwd, PlatformId, PlatformName, IP, IPArea, ClientType, Api)"
                       + "values(now(), @UserName, @Password, @RealName, @CellPhone, @WithdrawPwd, @PlatformId, @PlatformName, @IP, @IPArea, @ClientType, @Api)";
            return DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static AppUser GetForm(int keyValue)
        {
            string sql = "select * from app_user where ID=@ID";
            return DBHelper.GetOne<AppUser>(sql, new { ID = keyValue });
        }
    }
}
