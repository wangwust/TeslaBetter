using System;

namespace Tesla.Model
{
    /// <summary>
    /// 过滤IP
    /// </summary>
    public class SysFilterIP : BaseEntity<SysFilterIP>, ICreate, IModify, IDelete
    {
        /// <summary>
        /// 过滤主键
        /// </summary>		
        public string F_Id { get; set; }
        
        /// <summary>
        /// 类型
        /// </summary>		
        public bool F_Type { get; set; }
        
        /// <summary>
        /// 开始IP
        /// </summary>		
        public string F_StartIP { get; set; }
        
        /// <summary>
        /// 结束IP
        /// </summary>		
        public string F_EndIP { get; set; }
        
        /// <summary>
        /// 排序码
        /// </summary>		
        public int F_SortCode { get; set; }
        
        /// <summary>
        /// 删除标志
        /// </summary>		
        public bool? F_DeleteMark { get; set; }
        
        /// <summary>
        /// 有效标志
        /// </summary>		
        public bool F_EnabledMark { get; set; }
        
        /// <summary>
        /// 描述
        /// </summary>		
        public string F_Description { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>		
        public DateTime? F_CreatorTime { get; set; }
        
        /// <summary>
        /// 创建用户
        /// </summary>		
        public string F_CreatorUserId { get; set; }
        
        /// <summary>
        /// 最后修改时间
        /// </summary>		
        public DateTime? F_LastModifyTime { get; set; }
        
        /// <summary>
        /// 最后修改用户
        /// </summary>		
        public string F_LastModifyUserId { get; set; }
        
        /// <summary>
        /// 删除时间
        /// </summary>		
        public DateTime? F_DeleteTime { get; set; }
        
        /// <summary>
        /// 删除用户
        /// </summary>		
        public string F_DeleteUserId { get; set; }
    }
}

