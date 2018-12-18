using System;
using System.Collections.Generic;

namespace Tesla.Model
{
    /// <summary>
    /// BJKCPickerResponse
    /// </summary>
    public class BJKCPickerResponse
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        public BJKCResult result { get; set; }
    }

    /// <summary>
    /// BJKCResult
    /// </summary>
    public class BJKCResult
    {
        /// <summary>
        /// 结果码
        /// </summary>
        public int businessCode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public List<BJKCData> data { get; set; }
    }

    /// <summary>
    /// BJKCData
    /// </summary>
    public class BJKCData
    {
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime date { get; set; }

        /// <summary>
        /// 列表
        /// </summary>
        public List<BJKCCount> list { get; set; }
    }

    /// <summary>
    /// BJKCCount
    /// </summary>
    public class BJKCCount
    {
        /// <summary>
        /// 车道
        /// </summary>
        public int rank { get; set; }

        /// <summary>
        /// 单总数
        /// </summary>
        public int singleCount { get; set; }

        /// <summary>
        /// 双总数
        /// </summary>
        public int doubleCount { get; set; }

        /// <summary>
        /// 大总数
        /// </summary>
        public int bigCount { get; set; }

        /// <summary>
        /// 小总数
        /// </summary>
        public int smallCount { get; set; }
    }
}
