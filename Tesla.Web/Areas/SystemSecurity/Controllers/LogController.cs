using Tesla.App;
using Tesla.Utils;
using System.Web.Mvc;

namespace Tesla.Web.Areas.SystemSecurity.Controllers
{
    public class LogController : BaseController
    {
        private LogApp logApp = new LogApp();

        [HttpGet]
        public ActionResult RemoveLog()
        {
            return View();
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            var data = new
            {
                rows = logApp.GetList(pagerInfo, queryJson),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
            return Content(data.ToJson());
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRemoveLog(string keepTime)
        {
            logApp.RemoveLog(keepTime);
            return Success("清空成功。");
        }
    }
}
