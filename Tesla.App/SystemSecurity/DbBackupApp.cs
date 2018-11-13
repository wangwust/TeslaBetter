using Tesla.Model;
using Tesla.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tesla.App
{
    public class DbBackupApp
    {
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<SysDbBackup> GetList(string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string sql = "select * from Sys_DbBackup where 1=1 ";
            string keyword = string.Empty;
            if (!queryParam["condition"].IsEmpty() && !queryParam["keyword"].IsEmpty())
            {
                string condition = queryParam["condition"].ToString();
                keyword = queryParam["keyword"].ToString();
                switch (condition)
                {
                    case "DbName":
                        sql += "and F_DbName like @DbName ";
                        break;
                    case "FileName":
                        sql += "and F_FileName like @DbName ";
                        break;
                }
            }
            sql += "order by F_BackupTime desc";
            return DBHelper.GetList<SysDbBackup>(sql, new { DbName = keyword }).ToList();
        }

        /// <summary>
        /// 获取指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysDbBackup GetForm(string keyValue)
        {
            string sql = "select * from Sys_DbBackup where F_Id=@Id";
            return DBHelper.GetOne<SysDbBackup>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        /// <returns></returns>
        public int ClearData()
        {
            string sql = @"truncate table app_log;
                           truncate table app_betorder;
                           truncate table app_betparam;
                           truncate table app_charge;
                           truncate table app_withdraw; ";
            return DBHelper.Execute(sql);
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "delete from Sys_DbBackup where F_Id=@Id";
            DBHelper.Execute(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 提交表单
        /// </summary>
        /// <param name="model"></param>
        public void SubmitForm(SysDbBackup model)
        {
            model.F_Id = PublicFunction.GUID();
            model.F_EnabledMark = true;
            model.F_BackupTime = DateTime.Now;

            string sql = "insert into Sys_DbBackup values (@F_Id, @F_BackupType, @F_DbName, @F_FileName, "
                       + "@F_FileSize, @F_FilePath, @F_BackupTime, @F_SortCode, @F_DeleteMark, @F_EnabledMark, "
                       + "@F_Description, @F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, @F_LastModifyUserId, "
                       + "@F_DeleteTime, @F_DeleteUserId)";
            DBHelper.Execute(sql, model);
        }
    }
}
