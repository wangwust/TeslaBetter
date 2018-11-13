using Tesla.Utils;
using Tesla.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tesla.App
{
    /// <inheritdoc />
    /// <summary>
    /// 角色App
    /// </summary>
    public class RoleApp
    {
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        /// <summary>
        /// 读取角色列表
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

            sql += "and F_Category = 1 order by F_SortCode";

            return DBHelper.GetList<SysRole>(sql, new { FullName = "%" + keyword + "%" });
        }

        /// <summary>
        /// 根据主键值获取角色
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysRole GetForm(string keyValue)
        {
            string sql = "select * from sys_role where F_Id=@Id";
            return DBHelper.GetOne<SysRole>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定角色
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

                sql = "delete from sys_roleauthorize where F_ObjectId=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 修改/新增角色
        /// </summary>
        /// <param name="model"></param>
        /// <param name="permissionIds"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysRole model, string[] permissionIds, string keyValue)
        {
            var moduleData = moduleApp.GetList();
            var buttonData = moduleButtonApp.GetList();
            var LoginInfo = OperatorProvider.Provider.GetCurrent();

            //1、保存角色
            bool isAdd = string.IsNullOrEmpty(keyValue);
            string sql;
            if (!isAdd)
            {
                sql = "update sys_role set F_OrganizeId=@F_OrganizeId, "
                    + "F_EnCode=@F_EnCode, F_FullName=@F_FullName, F_Type=@F_Type, F_AllowEdit=@F_AllowEdit, "
                    + "F_AllowDelete=@F_AllowDelete, F_SortCode=@F_SortCode, F_EnabledMark=@F_EnabledMark,  "
                    + "F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_role (F_Id, F_OrganizeId, F_Category, F_EnCode, F_FullName, "
                    + "F_Type, F_AllowEdit, F_AllowDelete, F_SortCode, F_DeleteMark, F_EnabledMark, "
                    + "F_Description, F_CreatorTime, F_CreatorUserId) values (@F_Id, @F_OrganizeId, @F_Category, @F_EnCode, @F_FullName, "
                    + "@F_Type, @F_AllowEdit, @F_AllowDelete, @F_SortCode, @F_DeleteMark, @F_EnabledMark, "
                    + "@F_Description, @F_CreatorTime, @F_CreatorUserId)";
                model.F_Category = 1;
                model.Create();
            }

            int result = DBHelper.Execute(sql, model);
            if (result < 0)
            {
                return;
            }

            //2、保存权限
            IList<SysRoleAuthorize> authList = new List<SysRoleAuthorize>();
            IList<SysModule> moduleList;
            IList<SysModuleButton> btnList;
            foreach (var itemId in permissionIds)
            {
                SysRoleAuthorize auth = new SysRoleAuthorize();
                auth.F_Id = PublicFunction.GUID();
                auth.F_ObjectType = 1;
                auth.F_ObjectId = model.F_Id;
                auth.F_ItemId = itemId;
                auth.F_CreatorTime = model.F_CreatorTime;
                auth.F_CreatorUserId = model.F_CreatorUserId;

                moduleList = moduleData.Where(t => t.F_Id == itemId).ToList();
                if (moduleList.Count != 0)
                {
                    auth.F_ItemType = 1;
                }

                btnList = buttonData.Where(t => t.F_Id == itemId).ToList();
                if (btnList.Count != 0)
                {
                    auth.F_ItemType = 2;
                }

                authList.Add(auth);
            }

            sql = "delete from sys_roleauthorize where F_ObjectId=@ObjectId";
            result = DBHelper.Execute(sql, new { ObjectId = model.F_Id });
            if (result < 0)
            {
                return;
            }

            sql = "insert into sys_roleauthorize (F_Id, F_ItemType, F_ItemId, F_ObjectType, "
                + "F_ObjectId, F_SortCode, F_CreatorTime, F_CreatorUserId) values(@F_Id, @F_ItemType, @F_ItemId, @F_ObjectType, "
                + "@F_ObjectId, @F_SortCode, @F_CreatorTime, @F_CreatorUserId)";
            DBHelper.Execute(sql, authList);
        }
    }
}
