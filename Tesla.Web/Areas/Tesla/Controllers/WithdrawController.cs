using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;
using Tesla.Web.Areas.Tesla.Model;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// 提现记录
    /// </summary>
    public class WithdrawController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            ChargeParam param = string.IsNullOrEmpty(queryJson) ? new ChargeParam() : queryJson.ToEntity<ChargeParam>();

            pagerInfo.PKField = "ID";
            pagerInfo.TableName = "app_withdraw";
            pagerInfo.QueryString = param.QuerySql;

            List<Withdraw> list = WithdrawApp.GetList(pagerInfo);

            var data = new
            {
                rows = WithdrawApp.GetList(pagerInfo),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
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
        public ActionResult SubmitForm(Withdraw model)
        {
            model.CreateTime = DateTime.Now;
            int result = WithdrawApp.Insert(model);
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
            int result = WithdrawApp.Delete(keyValue);
            return Auto(result);
        }
    }
}