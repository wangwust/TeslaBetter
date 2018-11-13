/*******************************************************************************
 * Copyright © 2018 Tesla 版权所有
 * Author: Tony Stack


*********************************************************************************/
using Tesla.Model;
using System.Collections.Generic;
using System.Linq;

namespace Tesla.App
{
    /// <summary>
    /// 过滤IP APP
    /// </summary>
    public class FilterIPApp
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<SysFilterIP> GetList(string keyword)
        {
            string sql = "select * from Sys_FilterIP where 1=1 ";
            if (!string.IsNullOrEmpty(keyword))
            {
                sql += "and F_StartIP like @StartIP ";
            }
            sql += "order by F_DeleteTime desc";
            return DBHelper.GetList<SysFilterIP>(sql, new { StartIP = "%" + keyword + "%" }).ToList();

            //TODO:EF代码
            /*
            var expression = ExtLinq.True<FilterIPEntity>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.F_StartIP.Contains(keyword));
            }
            return service.IQueryable(expression).OrderByDescending(t => t.F_DeleteTime).ToList();
             */
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysFilterIP GetForm(string keyValue)
        {
            string sql = "select * from Sys_FilterIP where F_Id=@Id";
            return DBHelper.GetOne<SysFilterIP>(sql, new { Id = keyValue });

            //TODO:EF代码
            //return service.FindEntity(keyValue);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "delete from Sys_FilterIP where F_Id=@Id";
            DBHelper.Execute(sql, new { Id = keyValue });

            //TODO:EF代码
            //service.Delete(t => t.F_Id == keyValue);
        }

        /// <summary>
        /// 更新/新增实体
        /// </summary>
        /// <param name="filterIP"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysFilterIP filterIP, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update Sys_FilterIP set F_Type=@F_Type, F_StartIP=@F_StartIP, F_EndIP=@F_EndIP, "
                    + "F_SortCode=@F_SortCode, F_EnabledMark=@F_EnabledMark, F_Description=@F_Description, "
                    + "F_LastModifyTime=@F_LastModifyTime, F_LastModifyUserId=@F_LastModifyUserId";
                filterIP.Modify(keyValue);
            }
            else
            {
                sql = "insert intp Sys_FilterIP values (@F_Id, F_Type, F_StartIP, F_EndIP, F_SortCode, "
                    + "F_DeleteMark, F_EnabledMark, F_Description, F_CreatorTime, F_CreatorUserId)";
                filterIP.Create();
            }

            DBHelper.Execute(sql, filterIP);

            //TODO:EF代码
            /*
            if (!string.IsNullOrEmpty(keyValue))
            {
                filterIPEntity.Modify(keyValue);
                service.Update(filterIPEntity);
            }
            else
            {
                filterIPEntity.Create();
                service.Insert(filterIPEntity);
            }
             */
        }
    }
}
