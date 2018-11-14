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
            Dictionary<string, string> headerDic = new Dictionary<string, string>
            {
                { "Client-Type", param.ClientType },
                { "staffid", param.PlatformId },
                { "timestamp", DateTime.Now.ToTimestamp().ToString() }
            };

            Dictionary<string, string> paramDic = new Dictionary<string, string>
            {
                { "username", param.UserName },
                { "password", param.Password },
            };

            string result = HttpHelper.HttpPost(param.LoginApi + "/user/login", paramDic, headerDic, null);
            ApiResponse<LoginResponse> reponse = result.ToEntity<ApiResponse<LoginResponse>>();
            return reponse;
        }
    }
}
