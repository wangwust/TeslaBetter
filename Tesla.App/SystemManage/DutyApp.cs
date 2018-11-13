using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 职责
    /// </summary>
    public class DutyApp
    {
        /// <summary>
        /// 获取职责列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<SysRole> GetList(string keyword = "")
        {
            string sql = "select * from sys_role where 1=1 ";
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += "and (F_FullName like @FullName or F_EnCode like @FullName) ";
            }

            sql += "and F_Category = 2 order by F_SortCode";

            return DBHelper.GetList<SysRole>(sql, new { FullName = "%" + keyword + "%" });
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysRole GetForm(string keyValue)
        {
            string sql = "select * from sys_role where F_Id=@Id";
            return DBHelper.GetOne<SysRole>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "select 1 from sys_user where F_RoleId=@Id";
            IList<SysUser> list = DBHelper.GetList<SysUser>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的角色包含了用户，请先删除这些用户或更改这些用户所属角色。");
            }
            else
            {
                sql = "delete from sys_role where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 更新/新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysRole model, string keyValue)
        {
            //1、保存角色
            bool isAdd = string.IsNullOrEmpty(keyValue);
            string sql;
            if (!isAdd)
            {
                sql = "update sys_role set F_OrganizeId=@F_OrganizeId, F_Category=@F_Category, "
                    + "F_EnCode=@F_EnCode, F_FullName=@F_FullName, F_Type=@F_Type, F_AllowEdit=@F_AllowEdit, "
                    + "F_AllowDelete=@F_AllowDelete, F_SortCode=@F_SortCode, F_EnabledMark=@F_EnabledMark,  "
                    + "F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.F_Category = 2;
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_role (F_Id, F_OrganizeId, F_Category, F_EnCode, F_FullName, "
                    + "F_Type, F_AllowEdit, F_AllowDelete, F_SortCode,  "
                    + "F_Description, F_CreatorTime, F_CreatorUserId) values (@F_Id, @F_OrganizeId, @F_Category, @F_EnCode, @F_FullName, "
                    + "@F_Type, @F_AllowEdit, @F_AllowDelete, @F_SortCode,  "
                    + "@F_Description, @F_CreatorTime, @F_CreatorUserId)";
                model.F_Category = 2;
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
