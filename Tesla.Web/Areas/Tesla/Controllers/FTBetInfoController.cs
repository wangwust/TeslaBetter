using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// FTBetInfoController
    /// </summary>
    public class FTBetInfoController : BaseController
    {
        private static int lotteryId = 55;

        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            List<AppBetInfo> list = BetInfoApp.GetList2(lotteryId);
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
            var data = BetInfoApp.GetOne(keyValue);
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
        public ActionResult SubmitForm(AppBetInfo model, string keyValue)
        {
            model.LotteryID = lotteryId;
            int result;
            if (!string.IsNullOrEmpty(keyValue))
            {
                model.ID = Convert.ToInt32(keyValue);
                result = BetInfoApp.Update(model);
            }
            else
            {
                result = BetInfoApp.Add(model);
            }

            return Auto(result);
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
        public ActionResult SetState(int keyValue, int state)
        {
            int result = BetInfoApp.UpdateState(keyValue, state);
            return Auto(result);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(int keyValue)
        {
            int result = BetInfoApp.Delete(keyValue);
            return Auto(result);
        }
    }
}