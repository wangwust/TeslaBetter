using Tesla.Utils;
using Tesla.Model;
using System;
using System.Collections.Generic;

namespace Tesla.App
{
    /// <summary>
    /// 日志组件
    /// </summary>
    public class LogApp
    {
        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public List<SysLog> GetList(PagerInfo pagerInfo, string queryJson)
        {
            var queryParam = queryJson.ToJObject();
            string sql = "1=1 ";

            string keyword = string.Empty;
            string timeType = string.Empty;
            string startTime = DateTime.Now.ToString("yyyy-MM-dd");
            string endTime = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            if (!queryParam["keyword"].IsEmpty())
            {
                keyword = queryParam["keyword"].ToString();
                sql += "and F_Account like '%" + keyword + "%' ";
            }

            if (!queryParam["timeType"].IsEmpty())
            {
                timeType = queryParam["timeType"].ToString();
                switch (timeType)
                {
                    case "1":
                        break;
                    case "2":
                        startTime = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                        break;
                    case "3":
                        startTime = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                        break;
                    case "4":
                        startTime = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
                        break;
                    default:
                        break;
                }
                sql += "and F_Date >= '" + startTime + "' and F_Date <= '" + endTime + "' ";
            }
            pagerInfo.TableName = "sys_log";
            pagerInfo.QueryString = sql;
            pagerInfo.PKField = "F_Id";
            return DBHelper.GetPageList<SysLog>(pagerInfo);
        }

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="keepTime"></param>
        public void RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }

            string sql = "delete from sys_log where F_Date <= @Date";
            DBHelper.Execute(sql, new { Date = operateTime });
        }

        /// <summary>
        /// 写日志到数据库
        /// </summary>
        /// <param name="result"></param>
        /// <param name="resultLog"></param>
        public void WriteDbLog(bool result, string resultLog)
        {
            SysLog log = new SysLog();
            log.F_Id = PublicFunction.GUID();
            log.F_Date = DateTime.Now;
            log.F_Account = OperatorProvider.Provider.GetCurrent().UserCode;
            log.F_NickName = OperatorProvider.Provider.GetCurrent().UserName;
            log.F_IPAddress = NetHelper.Ip;
            log.F_IPAddressName = NetHelper.GetLocation(log.F_IPAddress);
            log.F_Result = result;
            log.F_Description = resultLog;
            log.Create();

            string sql = "insert into sys_log values (@F_Id, @F_Date, @F_Account, @F_NickName, @F_Type, "
                       + "@F_IPAddress, @F_IPAddressName, @F_ModuleId, @F_ModuleName, @F_Result, @F_Description, "
                       + "@F_CreatorTime, @F_CreatorUserId)";
            DBHelper.Execute(sql, log);
        }

        /// <summary>
        /// 写日志到数据库
        /// </summary>
        /// <param name="log"></param>
        public void WriteDbLog(SysLog log)
        {
            log.F_Id = PublicFunction.GUID();
            log.F_Date = DateTime.Now;
            log.F_IPAddress = NetHelper.Ip;
            log.F_IPAddressName = NetHelper.GetLocation(log.F_IPAddress);
            log.Create();

            string sql = "insert into sys_log values (@F_Id, @F_Date, @F_Account, @F_NickName, @F_Type, "
                       + "@F_IPAddress, @F_IPAddressName, @F_ModuleId, @F_ModuleName, @F_Result, @F_Description, "
                       + "@F_CreatorTime, @F_CreatorUserId)";
            DBHelper.Execute(sql, log);
        }
    }
}
