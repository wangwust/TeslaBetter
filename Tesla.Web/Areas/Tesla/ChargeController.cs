using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;
using Tesla.Web.Areas.Tesla.Model;

namespace Tesla.Web.Areas.Tesla
{
    /// <summary>
    /// 充值记录
    /// </summary>
    public class ChargeController : BaseController
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
            pagerInfo.TableName = "app_charge";
            pagerInfo.QueryString = param.QuerySql;
            
            var data = new
            {
                rows = ChargeApp.GetList(pagerInfo),
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
        public ActionResult SubmitForm(Charge model)
        {
            model.CreateTime = DateTime.Now;
            int result = ChargeApp.Insert(model);
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
            int result = ChargeApp.Delete(keyValue);
            return Auto(result);
        }
    }
}