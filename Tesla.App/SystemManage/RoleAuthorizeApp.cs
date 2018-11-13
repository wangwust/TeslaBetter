using Tesla.Utils;
using Tesla.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tesla.App
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class RoleAuthorizeApp
    {
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        /// <summary>
        /// 取实体列表
        /// </summary>
        /// <param name="ObjectId"></param>
        /// <returns></returns>
        public IList<SysRoleAuthorize> GetList(string ObjectId)
        {
            string sql = "select * from sys_roleauthorize where F_ObjectId=@ObjectId";
            return DBHelper.GetList<SysRoleAuthorize>(sql, new { ObjectId = ObjectId });
        }

        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysModule> GetMenuList(string roleId)
        {
            List<SysModule> moduleList = new List<SysModule>();
            if (OperatorProvider.Provider.GetCurrent().IsAdmin)//系统管理员具有所有权限
            {
                moduleList = moduleApp.GetList().ToList();
            }
            else
            {
                List<SysModule> moduleData = moduleApp.GetList().ToList();

                string sql = "select * from sys_roleauthorize where F_ObjectId=@RoleId and F_ItemType=1";
                var authorizeData = DBHelper.GetList<SysRoleAuthorize>(sql, new { RoleId = roleId });

                foreach (var item in authorizeData)
                {
                    SysModule module = moduleData.Find(t => t.F_Id == item.F_ItemId);
                    if (module != null)
                    {
                        moduleList.Add(module);
                    }
                }
            }
            return moduleList.OrderBy(t => t.F_SortCode).ToList();
        }

        /// <summary>
        /// 获取按钮列表
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<SysModuleButton> GetButtonList(string roleId)
        {
            var data = new List<SysModuleButton>();
            if (OperatorProvider.Provider.GetCurrent().IsAdmin)
            {
                data = moduleButtonApp.GetList().ToList();
            }
            else
            {
                var buttonData = moduleButtonApp.GetList().ToList();

                string sql = "select * from sys_roleauthorize where F_ObjectId=@RoleId and F_ItemType=2";
                var authorizeData = DBHelper.GetList<SysRoleAuthorize>(sql, new { RoleId = roleId });

                foreach (var item in authorizeData)
                {
                    SysModuleButton moduleButtonEntity = buttonData.Find(t => t.F_Id == item.F_ItemId);
                    if (moduleButtonEntity != null)
                    {
                        data.Add(moduleButtonEntity);
                    }
                }
            }
            return data.OrderBy(t => t.F_SortCode).ToList();
        }

        /// <summary>
        /// 权限校验
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool ActionValidate(string roleId, string moduleId, string action)
        {
            var authorizeurldata = new List<AuthorizeActionModel>();
            var cachedata = CacheFactory.CreateCacheHelper().Get<List<AuthorizeActionModel>>("authorizeurldata_" + roleId);
            if (cachedata == null)
            {
                var moduledata = moduleApp.GetList().ToList();
                var buttondata = moduleButtonApp.GetList().ToList();

                string sql = "select * from sys_roleauthorize where F_ObjectId=@RoleId";
                var authorizeData = DBHelper.GetList<SysRoleAuthorize>(sql, new { RoleId = roleId });

                foreach (var item in authorizeData)
                {
                    if (item.F_ItemType == 1)
                    {
                        SysModule moduleEntity = moduledata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleEntity.F_Id, F_UrlAddress = moduleEntity.F_UrlAddress });
                    }
                    else if (item.F_ItemType == 2)
                    {
                        SysModuleButton moduleButtonEntity = buttondata.Find(t => t.F_Id == item.F_ItemId);
                        authorizeurldata.Add(new AuthorizeActionModel { F_Id = moduleButtonEntity.F_ModuleId, F_UrlAddress = moduleButtonEntity.F_UrlAddress });
                    }
                }
                CacheFactory.CreateCacheHelper().Set(authorizeurldata, "authorizeurldata_" + roleId, DateTime.Now.AddMinutes(5));
            }
            else
            {
                authorizeurldata = cachedata;
            }

            authorizeurldata = authorizeurldata.FindAll(t => t.F_Id.Equals(moduleId));
            foreach (var item in authorizeurldata)
            {
                if (!string.IsNullOrEmpty(item.F_UrlAddress))
                {
                    string[] url = item.F_UrlAddress.Split('?');
                    if (item.F_Id == moduleId && url[0] == action)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
