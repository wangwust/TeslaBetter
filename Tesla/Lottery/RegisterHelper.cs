using System;
using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// RegisterHelper
    /// </summary>
    public static class RegisterHelper
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name=""></param>
        public static ApiResponse<RegisterResponse> Register(RegisterParams param)
        {
            if (string.IsNullOrEmpty(param.IP))
            {
                return new ApiResponse<RegisterResponse> { code = -1, msg = "请求IP不能为空！" };
            }

            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() },
                { "x-forwarded-for", param.IP }
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string>
            {
                { "UserName", param.UserName },
                { "RealName", param.RealName },
                { "Phone", param.Phone },
                { "PassWord", param.Password },
                { "PayPwd", param.PayPwd },
            };

            string result = HttpHelper.HttpPost(param.Api + "/user/register", paramDic, headerDic, null);
            ApiResponse<RegisterResponse> reponse = result.ToEntity<ApiResponse<RegisterResponse>>();
            return reponse;
        }
    }
}
