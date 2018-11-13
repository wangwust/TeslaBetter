﻿using System;

namespace Tesla.Model
{
    /// <summary>
    /// 模块表单
    /// </summary>
    public class SysModuleForm : BaseEntity<SysModuleForm>, ICreate, IModify, IDelete
    {
        /// <summary>
        /// 表单主键
        /// </summary>		
        public string F_Id { get; set; }

        /// <summary>
        /// 模块主键
        /// </summary>		
        public string F_ModuleId { get; set; }

        /// <summary>
        /// 编码
        /// </summary>		
        public string F_EnCode { get; set; }

        /// <summary>
        /// 名称
        /// </summary>		
        public string F_FullName { get; set; }

        /// <summary>
        /// 表单控件Json
        /// </summary>		
        public string F_FormJson { get; set; }

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

