using System.Collections.Generic;
using System.Linq;
using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// PlatformApp
    /// </summary>
    public static class PlatformApp
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        public static List<AppPlatform> GetList()
        {
            string sql = "select * from app_platform";
            return DBHelper.GetList<AppPlatform>(sql).ToList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int SubmitForm(AppPlatform model)
        {
            string sql = "update app_platform set UpdateTime=now(), Api=@Api, Url=@Url where ID=@ID";
            return DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AppPlatform GetEntity(int id)
        {
            string sql = "select * from app_platform where ID=@id";
            return DBHelper.GetOne<AppPlatform>(sql, new { id });
        }
    }
}
