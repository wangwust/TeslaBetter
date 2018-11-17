using System;
using System.Web.Mvc;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;
using Tesla.Web.Areas.Tesla.Model;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// AppUser
    /// </summary>
    public class AppUserController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string queryJson)
        {
            AppUserParam param = string.IsNullOrEmpty(queryJson) ? new AppUserParam() : queryJson.ToEntity<AppUserParam>();

            pagerInfo.TableName = "app_user";
            pagerInfo.PKField = "ID";
            pagerInfo.QueryString = param.QuerySql;

            var data = new
            {
                rows = AppUserApp.GetList(pagerInfo),
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
            var data = AppUserApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 新增操作
        /// </summary>
        /// <param name="model"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(AppUser model)
        {
            RegisterParams param = new RegisterParams
            {
                UserName = model.UserName,
                RealName = model.RealName,
                Phone = model.CellPhone,
                Password = model.Password,
                PayPwd = model.WithdrawPwd,
                IP = model.IP,
                PlatformId = model.PlatformId,
                ClientType = model.ClientType,
                Api = model.Api
            };

            ApiResponse<RegisterResponse> res = RegisterHelper.Register(param);
            if (!res.IsSucceed)
            {
                return Error($"注册失败。{res.msg}");
            }

            model.CreateTime = DateTime.Now;
            int result = AppUserApp.Insert(model);
            return Auto(result);
        }

        /// <summary>
        /// 获取余额
        /// </summary>
        /// <param name="keyValue"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult GetBalance(int keyValue)
        {
            AppUser model = AppUserApp.GetForm(keyValue);
            if (model == null)
            {
                return Error("当前用户不存在");
            }

            string errorMsg = string.Empty;
            if (IsTaskRun(model, ref errorMsg))
            {
                return Error(errorMsg);
            }

            LoginParams param = new LoginParams
            {
                UserName = model.UserName,
                Password = model.Password,
                Api = model.Api,
                PlatformId = model.PlatformId,
                ClientType = model.ClientType,
                IP = model.IP
            };

            ApiResponse<LoginResponse> response = LoginHelper.Login(param);
            if (!response.IsSucceed)
            {
                return Error($"获取余额失败。{response.msg}");
            }

            decimal balance = TeslaHelper.GetBalance(model.Api, model.IP, response.data);
            return Success($"当前用户余额：{balance}");
        }

        /// <summary>
        /// 任务是否在执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        private bool IsTaskRun(AppUser model, ref string errorMsg)
        {
            //当前用户是否正在运行
            AppTask task = TaskApp.GetOne();
            if (task.State == 1 && TeslaHelper.GetPlatformId(task.ServerCode) == model.PlatformId && task.ServerUserName == model.UserName)
            {
                errorMsg = $"任务：{task.Name}服务端正在使用用户：{model.UserName}。如需继续操作，请先将任务暂停";
                return true;
            }

            if (task.State == 1 && TeslaHelper.GetPlatformId(task.ClientCode) == model.PlatformId && task.ClientUserName == model.UserName)
            {
                errorMsg = $"任务：{task.Name}客户端正在使用用户：{model.UserName}。如需继续操作，请先将任务暂停";
                return true;
            }

            return false;
        }
    }
}