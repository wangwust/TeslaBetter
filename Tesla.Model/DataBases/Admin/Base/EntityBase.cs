using Tesla.Utils;
using System;

namespace Tesla.Model
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseEntity<T>
    {
        /// <summary>
        /// 新增 主要是设置Id、创建时间等字段
        /// </summary>
        public void Create()
        {
            var entity = this as ICreate;
            entity.F_Id = PublicFunction.GUID();
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_CreatorUserId = LoginInfo.UserId;
            }
            entity.F_CreatorTime = DateTime.Now;
        }

        /// <summary>
        /// 修改 设置修改时间等字段
        /// </summary>
        /// <param name="keyValue"></param>
        public void Modify(string keyValue)
        {
            var entity = this as IModify;
            entity.F_Id = keyValue;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_LastModifyUserId = LoginInfo.UserId;
            }
            entity.F_LastModifyTime = DateTime.Now;
        }

        /// <summary>
        /// 删除 设置删除标示等字段
        /// </summary>
        public void Remove()
        {
            var entity = this as IDelete;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                entity.F_DeleteUserId = LoginInfo.UserId;
            }
            entity.F_DeleteTime = DateTime.Now;
            entity.F_DeleteMark = true;
        }
    }
}
