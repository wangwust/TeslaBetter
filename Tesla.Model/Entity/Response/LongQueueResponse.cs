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
        public List<LongQueue> LongQueueList => this.clInfo.ToEntity<List<LongQueue>>();
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
