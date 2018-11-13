using System.Web.Mvc;
using Tesla.App;
using Tesla.Utils;
using Tesla.Web.Areas.Tesla.Model;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    public class AppLogController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            AppLogParam param = string.IsNullOrEmpty(queryJson) ? new AppLogParam() : queryJson.ToEntity<AppLogParam>();

            pagerInfo.TableName = "app_log";
            pagerInfo.PKField = "ID";
            pagerInfo.QueryString = param.QuerySql;

            var data = new
            {
                rows = AppLogApp.GetList(pagerInfo),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
            return Content(data.ToJson());
        }

        /// <summary>
        /// 取实体
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(int keyValue)
        {
            var data = AppLogApp.GetForm(keyValue);
            return Content(data.ToJson());
        }
    }
}