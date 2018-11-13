using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 模块App
    /// </summary>
    public class ModuleApp
    {
        /// <summary>
        /// 获取所有的模块
        /// </summary>
        /// <returns></returns>
        public IList<SysModule> GetList()
        {
            string sql = "select * from sys_module where 1=1";
            return DBHelper.GetList<SysModule>(sql);    
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysModule GetForm(string keyValue)
        {
            string sql = "select * from sys_module where F_Id=@Id";
            return DBHelper.GetOne<SysModule>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "select 1 from sys_module where F_ParentId=@Id";
            IList<SysModule> list = DBHelper.GetList<SysModule>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                sql = "delete from sys_module where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 更新/删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysModule model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_module set F_ParentId=@F_ParentId, F_Layers=@F_Layers, F_EnCode=@F_EnCode, "
                    + "F_FullName=@F_FullName, F_Icon=@F_Icon, F_UrlAddress=@F_UrlAddress, "
                    + "F_Target=@F_Target, F_IsMenu=@F_IsMenu, F_IsExpand=@F_IsExpand, F_IsPublic=@F_IsPublic, "
                    + "F_AllowEdit=@F_AllowEdit, F_AllowDelete=@F_AllowDelete, F_SortCode=@F_SortCode, "
                    + "F_EnabledMark=@F_EnabledMark, F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId, F_Show=@F_Show where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_module values (@F_Id, @F_ParentId, @F_Layers, @F_EnCode, @F_FullName, "
                    + "@F_Icon, @F_UrlAddress, @F_Target, @F_IsMenu, @F_IsExpand, @F_IsPublic, @F_AllowEdit, "
                    + "@F_AllowDelete, @F_SortCode, @F_DeleteMark, @F_EnabledMark, @F_Description, "
                    + "@F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, @F_LastModifyUserId, "
                    + "@F_DeleteTime, @F_DeleteUserId, @F_Show)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
