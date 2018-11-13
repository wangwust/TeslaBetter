using Tesla.Model;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 选项明细App
    /// </summary>
    public class ItemsDetailApp
    {
        /// <summary>
        /// 获取实体列表
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public IList<SysItemsDetail> GetList(string itemId = "", string keyword = "")
        {
            string sql = "select * from sys_itemsdetail where 1=1 ";
            if (!string.IsNullOrEmpty(itemId))
            {
                sql += "and F_ItemId=@ItemId ";
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                sql += "and (F_ItemName like @Keyword or F_ItemCode like @Keyword) ";
            }

            sql += "order by F_SortCode";

            return DBHelper.GetList<SysItemsDetail>(sql, new { ItemId = itemId, Keyword = "%" + keyword + "%" });
        }

        /// <summary>
        /// 根据编码获取实体
        /// </summary>
        /// <param name="enCode"></param>
        /// <returns></returns>
        public IList<SysItemsDetail> GetItemList(string enCode)
        {
            string sql = "select d.* from sys_itemsdetail d inner join sys_items i on i.F_Id = d.F_ItemId "
                       + "where i.F_EnCode = @enCode and d.F_EnabledMark = 1 and d.F_DeleteMark = 0 "
                       + "order by d.F_SortCode asc";

            return DBHelper.GetList<SysItemsDetail, SysItems, SysItemsDetail>(sql,
                (detail, item) =>
                {
                    detail.ItemOwner = item;
                    return detail;
                }, new { enCode = enCode }, "F_DeleteUserId");
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public SysItemsDetail GetForm(string keyValue)
        {
            string sql = "select * from sys_itemsdetail where F_Id=@Id";
            return DBHelper.GetOne<SysItemsDetail>(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 删除指定实体
        /// </summary>
        /// <param name="keyValue"></param>
        public void DeleteForm(string keyValue)
        {
            string sql = "delete from sys_itemsdetail where F_Id=@Id";
            DBHelper.Execute(sql, new { Id = keyValue });
        }

        /// <summary>
        /// 更新/新增
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        public void SubmitForm(SysItemsDetail model, string keyValue)
        {
            string sql;
            if (!string.IsNullOrEmpty(keyValue))
            {
                sql = "update sys_itemsdetail set F_ItemId=@F_ItemId, F_ParentId=@F_ParentId, "
                    + "F_ItemCode=@F_ItemCode, F_ItemName=@F_ItemName, F_SimpleSpelling=@F_SimpleSpelling, "
                    + "F_IsDefault=@F_IsDefault, F_SortCode=@F_SortCode, F_EnabledMark=@F_EnabledMark,  "
                    + "F_Description=@F_Description, F_LastModifyTime=@F_LastModifyTime, "
                    + "F_LastModifyUserId=@F_LastModifyUserId where F_Id=@F_Id";
                model.Modify(keyValue);
            }
            else
            {
                sql = "insert into sys_itemsdetail values (@F_Id, @F_ItemId, @F_ParentId, @F_ItemCode, "
                    + "@F_ItemName, @F_SimpleSpelling, @F_IsDefault, @F_Layers, @F_SortCode, @F_DeleteMark, "
                    + "@F_EnabledMark, @F_Description, @F_CreatorTime, @F_CreatorUserId, @F_LastModifyTime, "
                    + "@F_LastModifyUserId, @F_DeleteTime, @F_DeleteUserId)";
                model.Create();
            }

            DBHelper.Execute(sql, model);
        }
    }
}
