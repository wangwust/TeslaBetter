using System;
using System.Collections.Generic;
using System.Linq;
using Tesla.Model;

namespace Tesla.App
{
    /// <summary>
    /// 任务App
    /// </summary>
    public static class TaskApp
    {
        /// <summary>
        /// 获取任务
        /// </summary>
        /// <returns></returns>
        public static AppTask GetOne()
        {
            string sql = "select * from app_task where State = 1 limit 1";
            return DBHelper.GetOne<AppTask>(sql);
        }

        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        public static List<AppTask> GetList()
        {
            string sql = "select * from app_task";
            return DBHelper.GetList<AppTask>(sql).ToList();
        }

        /// <summary>
        /// 获取任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static AppTask GetOne(int taskID)
        {
            string sql = "select * from app_task where ID=@ID";
            return DBHelper.GetOne<AppTask>(sql, new { ID = taskID });
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        public static int UpdateState(AppTask task)
        {
            string sql = $"update app_task set State = @State, UpdateTime=now(), LastStopReason=@LastStopReason where ID=@ID";
            return DBHelper.Execute(sql, task);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int SubmitForm(AppTask model)
        {
            string sql = "update app_task set UpdateTime=now(), StartHour=@StartHour, EndHour=@EndHour, SingleMoney=@SingleMoney, ServerCode=@ServerCode, "
                       + "ServerApi=@ServerApi, ServerUserName=@ServerUserName, ServerUserPwd=@ServerUserPwd, ServerDeviceType=@ServerDeviceType, "
                       + "ServerMaxNumCount=@ServerMaxNumCount, ServerMinNumCount=@ServerMinNumCount, ClientCode=@ClientCode, ClientApi=@ClientApi, "
                       + "ClientUserName=@ClientUserName, ClientUserPwd=@ClientUserPwd, ClientDeviceType=@ClientDeviceType where ID=@ID";
            return DBHelper.Execute(sql, model);
        }
    }
}
