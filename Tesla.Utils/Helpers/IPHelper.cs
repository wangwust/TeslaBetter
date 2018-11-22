using System.Text.RegularExpressions;

namespace Tesla.Utils
{
    /// <summary>
    /// IPHelper
    /// </summary>
    public static class IPHelper
    {
        /// <summary>
        /// IP转换为整型
        /// </summary>
        /// <param name="ip"></param>
        public static long IPToLong(string ip)
        {
            if (string.IsNullOrEmpty(ip))
            {
                return -1;
            }

            ip = ip.Trim();
            if (ip == "::1")
            {
                ip = "127.0.0.1";
            }

            Regex regex = new Regex(@"[^0-9.]");
            ip = regex.Replace(ip, "");

            string[] startIPArray = ip.Split('.');
            if (startIPArray.Length != 4)
            {
                return -1;
            }

            long[] startIPNum = new long[4];
            for (int i = 0; i < 4; i++)
            {
                if (string.IsNullOrEmpty(startIPArray[i]))
                {
                    return -1;
                }

                startIPNum[i] = long.Parse(startIPArray[i].Trim());
            }

            // 各个数字乘以相应的数量级
            long num = startIPNum[0] * 256 * 256 * 256 + startIPNum[1] * 256 * 256 + startIPNum[2] * 256 + startIPNum[3];
            return num;
        }
    }
}
