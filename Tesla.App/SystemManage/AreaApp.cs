using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 区域App
    /// </summary>
    public class AreaApp
    {
        /// <summary>
        /// 获取所有区域
        /// </summary>
        /// <returns></returns>
        public IList<SysArea> GetList()
        {
            string sql = "select * from sys_area where 1=1";
            return DBHelper.GetList<SysArea>(sql);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysArea GetEntity(string keyValue)
        {
            string sql = "select * from sys_area where F_Id=@Id";
            return DBHelper.GetOne<SysArea>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteEntity(string keyValue)
        {
            string sql = "select 1 from sys_area where F_ParentId=@Id";
            IList<SysArea> list = DBHelper.GetList<SysArea>(sql, new { Id = keyValue });
            if (list.Count > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                sql = "delete from sys_area where F_Id=@Id";
                DBHelper.Execute(sql, new { Id = keyValue });
            }
        }

        /// <summary>
        /// 提价表单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysArea model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_area set F_ParentId=@F_ParentId, F_Layers=@F_Layers, F_EnCode=@F_EnCode, "
                    + "F_FullName=@F_FullName, F_SimpleSpelling=@F_SimpleSpelling, F_SortCode=@F_SortCode, "
                    + "F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_area values (@F_Id, @F_ParentId, @F_Layers, @F_EnCode, @F_FullName, "
                    + "@F_SimpleSpelling, @F_SortCode, @F_DeleteMark, @F_EnabledMark, @F_Description, "
                    + "@F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, @F_LastModifyUserId, "
                    + "@F_DeleteTime, @F_DeleteUserId)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
