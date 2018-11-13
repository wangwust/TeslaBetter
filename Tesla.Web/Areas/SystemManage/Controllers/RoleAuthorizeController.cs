using Tesla.App;
/*******************************************************************************
 * Copyright © 2018 Tesla 版权所有
 * Author: Tony Stack


*********************************************************************************/
using Tesla.Utils;
using Tesla.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Tesla.Web.Areas.SystemManage.Controllers
{
    public class RoleAuthorizeController : BaseController
    {
        private RoleAuthorizeApp roleAuthorizeApp = new RoleAuthorizeApp();
        private ModuleApp moduleApp = new ModuleApp();
        private ModuleButtonApp moduleButtonApp = new ModuleButtonApp();

        /// <summary>
        /// 获取权限树
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public ActionResult GetPermissionTree(string roleId)
        {
            var moduledata = moduleApp.GetList();
            var buttondata = moduleButtonApp.GetList();
            var authorizeData = new List<SysRoleAuthorize>();
            if (!string.IsNullOrEmpty(roleId))
            {
                authorizeData = roleAuthorizeApp.GetList(roleId).ToList();
            }
            var treeList = new List<TreeViewModel>();
            foreach (SysModule item in moduledata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = moduledata.Count(t => t.F_ParentId == item.F_Id) != 0;
                tree.Id = item.F_Id;
                tree.Text = item.F_FullName;
                tree.Value = item.F_EnCode;
                tree.ParentId = item.F_ParentId;
                tree.IsExpand = true;
                tree.Complete = true;
                tree.ShowCheck = true;
                tree.CheckState = authorizeData.Count(t => t.F_ItemId == item.F_Id);
                tree.HasChildren = true;
                tree.Img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }

            foreach (SysModuleButton item in buttondata)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = buttondata.Count(t => t.F_ParentId == item.F_Id) != 0;
                tree.Id = item.F_Id;
                tree.Text = item.F_FullName;
                tree.Value = item.F_EnCode;
                tree.ParentId = item.F_ParentId == "0" ? item.F_ModuleId : item.F_ParentId;
                tree.IsExpand = true;
                tree.Complete = true;
                tree.ShowCheck = true;
                tree.CheckState = authorizeData.Count(t => t.F_ItemId == item.F_Id);
                tree.HasChildren = hasChildren;
                tree.Img = item.F_Icon == "" ? "" : item.F_Icon;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }
    }
}
