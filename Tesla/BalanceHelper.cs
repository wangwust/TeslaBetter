using System;
using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// 余额帮助类
    /// </summary>
    public static class BalanceHelper
    {
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static ApiResponse<BalanceResponse> GetBalance(BalanceParams param)
        {
            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", TeslaEnum.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string> { { "LoginName", param.UserName } };

            string result = HttpHelper.HttpPost(param.BalanceApi + "/user/balance", paramDic, headerDic, null);
            ApiResponse<BalanceResponse> reponse = result.ToEntity<ApiResponse<BalanceResponse>>();
            return reponse;
        }
    }
}
