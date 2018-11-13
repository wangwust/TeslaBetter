using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// BetParamApp
    /// </summary>
    public static class BetParamApp
    {
        /// <summary>
        /// 取一个
        /// </summary>
        /// <returns></returns>
        public static AppBetParam GetOne()
        {
            string sql = "select * from app_betparam";
            return DBHelper.GetOne<AppBetParam>(sql);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        public static bool Exist()
        {
            string sql = "select ID from app_betparam";
            return DBHelper.GetOne<AppBetParam>(sql) != null;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public static int Delete(int id)
        {
            string sql = "delete from app_betparam where ID=@id";
            return DBHelper.Execute(sql, new { id });
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Insert(AppBetParam model)
        {
            string sql = "insert into app_betparam(CreateTime, TaskId, TaskName, Params) "
                       + "values(@CreateTime, @TaskId, @TaskName, @Params)";
            return DBHelper.Execute(sql, model);
        }
    }
}
