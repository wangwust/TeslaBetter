using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Utils;

namespace Tesla.Web.Areas.SystemManage.Controllers
{
    /// <summary>
    /// IP
    /// </summary>
    public class IPController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            IPParam param = string.IsNullOrEmpty(queryJson) ? new IPParam() : queryJson.ToEntity<IPParam>();

            pagerInfo.TableName = "app_ip";
            pagerInfo.PKField = "ID";
            pagerInfo.QueryString = param.QuerySql;

            var data = new
            {
                rows = IPApp.GetList(pagerInfo),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
            return Content(data.ToJson());
        }
    }
}