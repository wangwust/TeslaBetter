using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 选项主表App
    /// </summary>
    public class ItemsApp
    {
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <returns></returns>
        public IList<SysItems> GetList()
        {
            string sql = "select * from sys_items where 1=1 ";
            return DBHelper.GetList<SysItems>(sql);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysItems GetForm(string keyValue)
        {
            string sql = "select * from sys_items where F_Id=@Id";
            return DBHelper.GetOne<SysItems>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "select 1 from sys_items where F_ParentId=@Id";
            IList<SysItems> list = DBHelper.GetList<SysItems>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                sql = "delete from sys_items where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 更新/新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysItems model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_items set F_ParentId=@F_ParentId, F_EnCode=@F_EnCode, "
                    + "F_FullName=@F_FullName, F_IsTree=@F_IsTree, F_Layers=@F_Layers, F_SortCode=@F_SortCode, "
                    + "F_EnabledMark=@F_EnabledMark, F_Description=@F_Description, "
                    + "F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_items values (@F_Id, @F_ParentId, @F_EnCode, @F_FullName, "
                    + "@F_IsTree, @F_Layers, @F_SortCode, @F_DeleteMark, @F_EnabledMark, "
                    + "@F_Description, @F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, "
                    + "@F_LastModifyUserId, @F_DeleteTime, @F_DeleteUserId)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
