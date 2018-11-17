using System;

namespace Tesla.Model
{
    /// <summary>
    /// AppUser
    /// </summary>
    public class AppUser
    {
        public int ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Password { get; set; }
        public string WithdrawPwd { get; set; }
        public string CellPhone { get; set; }
        public string PlatformId { get; set; }
        public string PlatformName { get; set; }
        public string IP { get; set; }
        public string ClientType { get; set; }
        public string Api { get; set; }
    }
}
