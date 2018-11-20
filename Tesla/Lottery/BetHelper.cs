using System;
using System.Collections.Generic;
using System.Linq;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// 投注帮助类
    /// </summary>
    public class BetHelper
    {
        /// <summary>
        /// 六合彩号码
        /// </summary>
        public static List<string> LHCNumberList = new List<string> { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49" };

        /// <summary>
        /// 投注
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResponse<BetResponse> Bet(BetParams param)
        {
            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
                { "x-forwarded-for", param.IP }
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string>
            {
                { "data", param.BetInfo },
                { "PeriodNumber", param.Issue },
            };

            string result = HttpHelper.HttpPost(param.Api + "/order/bet/85", paramDic, headerDic, null);
            ApiResponse<BetResponse> reponse = result.ToEntity<ApiResponse<BetResponse>>();
            return reponse;
        }

        /// <summary>
        /// 获取投注信息
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<string> GetBetInfo(int count)
        {
            if (count > 49)
            {
                count = 49;
            }

            if (count < 1)
            {
                count = 1;
            }

            List<string> list = LHCNumberList.OrderBy(r => RandomHelper.GetRandomSeed()).ToList();
            List<string> list2 = new List<string>();
            for (int i = 0; i < count; i++)
            {
                list2.Add(list[i]);
            }

            return list2;
        }

        /// <summary>
        /// 获取投注对象
        /// </summary>
        /// <param name="response"></param>
        /// <param name="numList"></param>
        /// <returns></returns>
        public static BetParams GetBetParams(LoginResponse response, List<string> numList, decimal money)
        {
            List<BetInfo> list = (from s in numList
                                  select new BetInfo
                                  {
                                      money = money,
                                      Number = Convert.ToInt32(s)
                                  }).ToList();
            return new BetParams
            {
                UserName = response.userName,
                PlatformId = response.companyPlatformID,
                Token = response.token,
                BetInfo = list.ToJson(),
            };
        }
    }
}
