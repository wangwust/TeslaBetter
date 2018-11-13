using System;

namespace Tesla.Model
{
    /// <summary>
    /// 修改接口
    /// </summary>
    public interface IModify
    {
        string F_Id { get; set; }

        string F_LastModifyUserId { get; set; }

        DateTime? F_LastModifyTime { get; set; }
    }
}