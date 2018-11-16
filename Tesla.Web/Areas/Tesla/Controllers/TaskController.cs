using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Tesla;
using Tesla.App;
using Tesla.Model;
using Tesla.Utils;

namespace Tesla.Web.Areas.Tesla.Controllers
{
    /// <summary>
    /// 任务
    /// </summary>
    public class TaskController : BaseController
    {
        /// <summary>
        /// 取列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(string keyword)
        {
            List<AppTask> list = TaskApp.GetList();
            return Content(list.ToJson());
        }

        /// <summary>
        /// 获取对象json字符串
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = TaskApp.GetOne(Convert.ToInt32(keyValue));
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
        public ActionResult SubmitForm(AppTask model, string keyValue)
        {
            model.ID = Convert.ToInt32(keyValue);
            int result = TaskApp.SubmitForm(model);
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
            AppTask task = new AppTask { ID = keyValue, State = state };
            if (state == 0)
            {
                task.LastStopReason = TaskStopReason.Manual;
            }
            else if(state == 1)
            {
                string errorMsg = string.Empty;
                if (!TeslaHelper.CheckCanStartTask(keyValue, ref errorMsg))
                {
                    return Error("任务不满足启动条件。原因：" + errorMsg);
                }
            }

            int result = TaskApp.UpdateState(task);
            return Auto(result);
        }

        /// <summary>
        /// 测试登录
        /// </summary>
        /// <param name="code"></param>
        /// <param name="api"></param>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult TestLogin(string code, string api, string userName, string pwd, string device, string ttip)
        {
            LoginParams param = new LoginParams
            {
                Api = api.Trim(),
                PlatformId = TeslaHelper.GetPlatformId(code.Trim()),
                UserName = userName.Trim(),
                Password = pwd.Trim(),
                ClientType = device.Trim(),
                IP = ttip
            };

            ApiResponse<LoginResponse> response = LoginHelper.Login(param);
            if (response.IsSucceed)
            {
                return Success($"登录成功。当前账户余额：{response.data.accountBalance}");
            }
            else
            {
                return Error($"登录失败。{response.msg}");
            }
        }
    }
}