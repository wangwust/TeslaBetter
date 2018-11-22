using System.Collections.Generic;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.App
{
    /// <summary>
    /// IPApp
    /// </summary>
    public static class IPApp
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <returns></returns>
        public static List<AppIP> GetList(PagerInfo pagerInfo)
        {
            return DBHelper.GetPageList<AppIP>(pagerInfo);
        }

        /// <summary>
        /// 根据ip取区域
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetArea(string ip)
        {
            long ipLong = IPHelper.IPToLong(ip);
            string sql = "select Area, Carrier from app_ip where StartIP2 <= @ip and EndIP2 >= @ip";
            AppIP model = DBHelper.GetOne<AppIP>(sql, new { ip = ipLong });
            if (model == null)
            {
                return "未知区域";
            }

            return model.Area + " - " + model.Carrier;
        }
    }
}
