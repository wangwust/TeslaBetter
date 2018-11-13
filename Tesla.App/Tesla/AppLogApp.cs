using System;
using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.App
{
    /// <summary>
    /// 服务日志
    /// </summary>
    public static class AppLogApp
    {
        /// <summary>
        /// 插入日志
        /// </summary>
        /// <param name="appLog"></param>
        /// <returns></returns>
        public static int Insert(AppLog appLog)
        {
            string sql = $"insert into app_log (CreateTime, CreateTimestamp, TaskId, TaskName, Source, Type, TypeText, Message, UserName) "
                       + "values(@CreateTime, @CreateTimestamp, @TaskId, @TaskName, @Source, @Type, @TypeText, @Message, @UserName)";
            return DBHelper.Execute(sql, appLog);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static List<AppLog> GetList(PagerInfo pagerInfo)
        {
            return DBHelper.GetPageList<AppLog>(pagerInfo);
        }

        /// <summary>
        /// 取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public static AppLog GetForm(int keyValue)
        {
            string sql = "select * from app_log where ID=@ID";
            return DBHelper.GetOne<AppLog>(sql, new { ID = keyValue });
        }
    }
}
