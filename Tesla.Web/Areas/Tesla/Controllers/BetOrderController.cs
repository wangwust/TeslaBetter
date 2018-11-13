using System.Web.Mvc;
using Tesla.App;
using Tesla.Utils;
using Tesla.Web.Areas.Tesla.Model;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    public class BetOrderController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            BetOrderParam param = string.IsNullOrEmpty(queryJson) ? new BetOrderParam() : queryJson.ToEntity<BetOrderParam>();

            pagerInfo.TableName = "app_betorder";
            pagerInfo.PKField = "ID";
            pagerInfo.QueryString = param.QuerySql;

            var data = new
            {
                rows = BetOrderApp.GetList(pagerInfo),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
            return Content(data.ToJson());
        }
    }
}