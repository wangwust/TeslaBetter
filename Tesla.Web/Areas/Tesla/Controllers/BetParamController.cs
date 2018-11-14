using System.Web.Mvc;
using Tesla.App;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// 客户端投注参数
    /// </summary>
    public class BetParamController : BaseController
    {
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            var model = BetParamApp.GetList();
            return Content(model.ToJson());
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
            var data = BetParamApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 删除局
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(int keyValue)
        {
            int result = BetParamApp.Delete(keyValue);
            return Auto(result);
        }
    }
}