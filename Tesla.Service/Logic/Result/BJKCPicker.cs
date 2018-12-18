using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Service
{
    /// <summary>
    /// BJKCPicker
    /// </summary>
    public static class BJKCPicker
    {
        /// <summary>
        /// https://1680118.com
        /// </summary>
        private static string url = "https://api.api68.com/pks/queryHistoryDataForDsdx.do?lotCode=10001";

        /// <summary>
        /// 开始执行
        /// </summary>
        public static void Run()
        {
            string result = HttpHelper.HttpGet(url);
            BJKCPickerResponse response = result.ToEntity<BJKCPickerResponse>();
            List<AppResult> list = new List<AppResult>();
            foreach(BJKCData data in response.result.data)
            {
                if(data.date >= DateTime.Now.Date)
                {
                    continue;
                }

                //foreach(BJKCCount count in data.list)
                //{
                //    AppResult 
                //}
            }
        }
    }
}
