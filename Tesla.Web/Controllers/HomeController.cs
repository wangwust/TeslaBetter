using System.Web.Mvc;

namespace Tesla.Web.Controllers
{
    [HandlerLogin]
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Default()
        {
            return View();
        }

        /// <summary>
        /// 统计信息
        /// </summary>
        /// <returns></returns>
        public ActionResult GetBetAndWinMoney()
        {
            return View();
        }
    }
}
