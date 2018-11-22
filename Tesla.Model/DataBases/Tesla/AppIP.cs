using System;

namespace Tesla.Model
{
    /// <summary>
    /// IP地址
    /// </summary>
    public class AppIP
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// CreateTime
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 起始IP
        /// </summary>
        public string StartIP { get; set; }

        /// <summary>
        /// 截止IP
        /// </summary>
        public string EndIP { get; set; }

        /// <summary>
        /// 起始IP2
        /// </summary>
        public long StartIP2 { get; set; }

        /// <summary>
        /// 截止IP2
        /// </summary>
        public long EndIP2 { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 运营商
        /// </summary>
        public string Carrier { get; set; }

        /// <summary>
        /// 是否国内
        /// </summary>
        public bool IsChina { get; set; }
    }
}
