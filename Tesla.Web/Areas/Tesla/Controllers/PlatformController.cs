using System.Collections.Generic;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// 平台
    /// </summary>
    public class PlatformController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string queryJson)
        {
            List<AppPlatform> list = PlatformApp.GetList();
            return Content(list.ToJson());
        }

        /// <summary>
        /// 获取对象json字符串
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(int keyValue)
        {
            var data = PlatformApp.GetEntity(keyValue);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 更新或新增操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AppPlatform model, int keyValue)
        {
            model.ID = keyValue;
            int result = PlatformApp.SubmitForm(model);
            return Auto(result);
        }
    }
}