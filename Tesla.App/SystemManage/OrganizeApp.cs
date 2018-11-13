using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 组织App
    /// </summary>
    public class OrganizeApp
    {
        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <returns></returns>
        public IList<SysOrganize> GetList()
        {
            string sql = "select * from sys_organize order by F_CreatorTime";
            return DBHelper.GetList<SysOrganize>(sql);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysOrganize GetForm(string keyValue)
        {
            string sql = "select * from sys_organize where F_Id=@Id";
            return DBHelper.GetOne<SysOrganize>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {

            string sql = "select 1 from sys_organize where F_ParentId=@Id";
            IList<SysOrganize> list = DBHelper.GetList<SysOrganize>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                sql = "delete from sys_organize where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 更新/新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysOrganize model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_organize set F_ParentId=@F_ParentId, F_Layers=@F_Layers, F_EnCode=@F_EnCode, "
                    + "F_FullName=@F_FullName, F_ShortName=@F_ShortName, F_CategoryId=@F_CategoryId, "
                    + "F_ManagerId=@F_ManagerId, F_TelePhone=@F_TelePhone, F_MobilePhone=@F_MobilePhone, "
                    + "F_WeChat=@F_WeChat, F_Fax=@F_Fax, F_Email=@F_Email, F_AreaId=@F_AreaId, "
                    + "F_Address=@F_Address, F_AllowEdit=@F_AllowEdit, F_AllowDelete=@F_AllowDelete, "
                    + "F_SortCode=@F_SortCode, F_LastModifyTime=@F_LastModifyTime, F_EnabledMark=@F_EnabledMark, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_organize values (@F_Id, @F_ParentId, @F_Layers, @F_EnCode, @F_FullName, "
                    + "@F_ShortName, @F_CategoryId, @F_ManagerId, @F_TelePhone, @F_MobilePhone, @F_WeChat, "
                    + "@F_Fax, @F_Email,@F_AreaId, @F_Address, @F_AllowEdit, @F_AllowDelete, @F_SortCode, "
                    + "@F_DeleteMark, @F_EnabledMark, @F_Description, "
                    + "@F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, @F_LastModifyUserId, "
                    + "@F_DeleteTime, @F_DeleteUserId)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
