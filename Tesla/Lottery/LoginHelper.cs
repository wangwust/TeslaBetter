using System;
using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla
{
    /// <summary>
    /// 登录帮助类
    /// </summary>
    public static class LoginHelper
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="param"></param>
        public static ApiResponse<LoginResponse> Login(LoginParams param)
        {
            if (string.IsNullOrEmpty(param.IP))
            {
                return new ApiResponse<LoginResponse> { code = -1, msg = "请求IP不能为空！" };
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
                { "username", param.UserName },
                { "password", param.Password },
            };

            string result = HttpHelper.HttpPost(param.Api + "/user/login", paramDic, headerDic, null);
            ApiResponse<LoginResponse> reponse = result.ToEntity<ApiResponse<LoginResponse>>();
            return reponse;
        }
    }
}
