using System;
using Tesla.Utils;

namespace Tesla.Model
{
    /// <summary>
    /// 投注参数表
    /// </summary>
    public class AppBetParam
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 任务ID
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// 任务名称
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// 投注参数
        /// </summary>
        public string Params { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BetParams BetParam => this.Params.ToEntity<BetParams>();

        /// <summary>
        /// 短消息
        /// </summary>
        public string ShortParams => this.Params.Length > 100 ? this.Params.Substring(0, 100) + "..." : this.Params;
    }
}
