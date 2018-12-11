using System;
using System.Collections.Generic;
using Tesla.Utils;

namespace Tesla.Model
{
    /// <summary>
    /// LongQueueResponse
    /// </summary>
    public class LongQueueResponse
    {
        /// <summary>
        /// clInfo
        /// </summary>
        public string clInfo { get; set; }

        /// <summary>
        /// LongQueue
        /// </summary>
        public List<LongQueue> LongQueueList
        {
            get
            {
                if (string.IsNullOrEmpty(this.clInfo))
                {
                    return new List<LongQueue>();
                }

                try
                {
                    return this.clInfo.ToEntity<List<LongQueue>>();
                }
                catch (Exception ex)
                {
                    return new List<LongQueue>();
                }
            }
        }
    }

    /// <summary>
    /// LongQueue
    /// </summary>
    public class LongQueue
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string PlayCateName { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Cont { get; set; }
    }
}
