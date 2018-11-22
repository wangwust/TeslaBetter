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
            if (string.IsNullOrEmpty(param.IP))
            {
                return new ApiResponse<BalanceResponse> { code = -1, msg = "请求IP不能为空！" };
            }

            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "username", param.UserName },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "token", param.Token },
                { "x-forwarded-for", param.IP }
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string> { { "LoginName", param.UserName } };

            string result = HttpHelper.HttpPost(param.Api + "/user/balance", paramDic, headerDic, null);
            ApiResponse<BalanceResponse> reponse = result.ToEntity<ApiResponse<BalanceResponse>>();
            return reponse;
        }
    }
}
