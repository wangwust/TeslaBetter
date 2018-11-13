using System;

namespace Tesla.Model
{
    /// <summary>
    /// 创建接口
    /// </summary>
    public interface ICreate
    {
        string F_Id { get; set; }

        string F_CreatorUserId { get; set; }

        DateTime? F_CreatorTime { get; set; }
    }
}