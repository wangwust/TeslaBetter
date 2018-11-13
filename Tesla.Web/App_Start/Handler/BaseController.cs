using Tesla.Utils;
using System.Web.Mvc;

namespace Tesla.Web
{
    /// <summary>
    /// 控制器基类
    /// </summary>
    [HandlerLogin]
    public abstract class BaseController : Controller
    {
        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Form()
        {
            return View();
        }

        [HttpGet]
        [HandlerAuthorize]
        public virtual ActionResult Details()
        {
            return View();
        }

        /// <summary>
        /// 自动
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual ActionResult Auto(int result)
        {
            if (result < 0)
            {
                return Error("操作失败");
            }
            else
            {
                return Success("操作成功");
            }
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message }.ToJson());
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual ActionResult Success(string message, object data)
        {
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = message, data = data }.ToJson());
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected virtual ActionResult Error(string message)
        {
            return Content(new AjaxResult { state = ResultType.error.ToString(), message = message }.ToJson());
        }
    }
}
