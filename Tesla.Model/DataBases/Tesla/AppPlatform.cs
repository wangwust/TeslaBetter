using System;

namespace Tesla.Model
{
    /// <summary>
    /// AppPlatform
    /// </summary>
    public class AppPlatform
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Code { get; set; }
        public string PlatformID { get; set; }
        public string Api { get; set; }
        public string Url { get; set; }
    }
}
