using Tesla.Utils;
using Tesla.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tesla.App
{
    /// <summary>
    /// 模块按钮App
    /// </summary>
    public class ModuleButtonApp
    {
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public IList<SysModuleButton> GetList(string moduleId = "")
        {
            string sql = "select * from sys_modulebutton where 1=1 ";
            if (!string.IsNullOrEmpty(moduleId))
            {
                sql += "and F_ModuleId=@ModuleId ";
            }
            sql += "order by F_SortCode ";

            return DBHelper.GetList<SysModuleButton>(sql, new { ModuleId = moduleId });
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysModuleButton GetForm(string keyValue)
        {
            string sql = "select * from sys_modulebutton where F_Id=@Id";
            return DBHelper.GetOne<SysModuleButton>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "select 1 from sys_modulebutton where F_ParentId=@Id";
            IList<SysModuleButton> list = DBHelper.GetList<SysModuleButton>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                sql = "delete from sys_modulebutton where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 更新/新增实体
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysModuleButton model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_modulebutton set F_ParentId=@F_ParentId, F_ParentId=@F_ParentId, "
                    + "F_Layers=@F_Layers, F_EnCode=@F_EnCode, F_FullName=@F_FullName, "
                    + "F_Icon=@F_Icon, F_Location=@F_Location, F_JsEvent=@F_JsEvent, F_UrlAddress=@F_UrlAddress, "
                    + "F_Split=@F_Split, F_IsPublic=@F_IsPublic,F_AllowEdit=@F_AllowEdit, "
                    + "F_AllowDelete=@F_AllowDelete, F_SortCode=@F_SortCode, F_EnabledMark=@F_EnabledMark, "
                    + "F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_modulebutton values (@F_Id, @F_ModuleId, @F_ParentId, @F_Layers, "
                    + "@F_EnCode, @F_FullName, @F_Icon, @F_Location, @F_JsEvent, @F_UrlAddress, @F_Split, "
                    + "@F_IsPublic, @F_AllowEdit, @F_AllowDelete, @F_SortCode, @F_DeleteMark, @F_EnabledMark, "
                    + "@F_Description, @F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, "
                    + "@F_LastModifyUserId, @F_DeleteTime, @F_DeleteUserId)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }

        /// <summary>
        /// 克隆按钮提交
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="ids"></param>
        public void SubmitCloneButton(string moduleId, string ids)
        {
            string[] arrayId = ids.Split(',');
            var data = this.GetList();
            IList<SysModuleButton> modelList = new List<SysModuleButton>();
            SysModuleButton model;
            IList<SysModuleButton> tmpList;
            foreach (string id in arrayId)
            {
                tmpList = data.Where(t => t.F_Id == id).ToList();
                if (tmpList.Count == 0)
                {
                    continue;
                }

                model = tmpList[0];
                model.F_Id = PublicFunction.GUID();
                model.F_ModuleId = moduleId;
                modelList.Add(model);
            }

            string sql = "insert into sys_modulebutton values (@F_Id, @F_ModuleId, @F_ParentId, @F_Layers, "
                       + "@F_EnCode, @F_FullName, @F_Icon, @F_Location, @F_JsEvent, @F_UrlAddress, @F_Split, "
                       + "@F_IsPublic, @F_AllowEdit, @F_AllowDelete, @F_SortCode, @F_DeleteMark, @F_EnabledMark, "
                       + "@F_Description, @F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, "
                       + "@F_LastModifyUserId, @F_DeleteTime, @F_DeleteUserId)";
            DBHelper.Execute(sql, modelList);
        }
    }
}
