using Tesla.App;
using Tesla.Utils;
using Tesla.Model;
using System.Web.Mvc;


namespace Tesla.Web.Areas.SystemManage.Controllers
{
    public class UserController : BaseController
    {
        private UserApp userApp = new UserApp();
        private UserLogOnApp userLogOnApp = new UserLogOnApp();

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="pagerInfo"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetGridJson(PagerInfo pagerInfo, string keyword)
        {
            string sql = string.Empty;
            if (!string.IsNullOrEmpty(keyword))
            {
                sql = "F_Account like '%{0}%' or F_RealName like '%{0}%' or F_MobilePhone like '%{0}%'";
                sql = string.Format(sql, keyword);
            }

            pagerInfo.PKField = "F_Id";
            pagerInfo.TableName = "Sys_User";
            pagerInfo.QueryString = sql;
            var data = new
            {
                rows = userApp.GetList(pagerInfo),
                total = pagerInfo.total,
                page = pagerInfo.page,
                records = pagerInfo.records
            };
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = userApp.GetForm(keyValue);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 更新/新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userLogOn"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(SysUser user, SysUserLogOn userLogOn, string keyValue)
        {
            userApp.SubmitForm(user, userLogOn, keyValue);
            return Success("操作成功。");
        }

        [HttpPost]
        [HandlerAuthorize]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteForm(string keyValue)
        {
            //系统内置账户不允许删除
            if (keyValue.Trim() == "9f2ec079-7d0f-4fe2-90ab-8b09a8302aba") 
            {
                return Error("系统内置账户，不允许删除！");
            }

            userApp.DeleteForm(keyValue);
            return Success("删除成功。");
        }

        [HttpGet]
        public ActionResult RevisePassword()
        {
            return View();
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userPassword"></param>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRevisePassword(string userPassword, string keyValue)
        {
            userLogOnApp.RevisePassword(userPassword, keyValue);
            return Success("重置密码成功。");
        }

        /// <summary>
        /// 禁用账户
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult DisabledAccount(string keyValue)
        {
            SysUser user = new SysUser();
            user.F_Id = keyValue;
            user.F_EnabledMark = false;
            userApp.SetAccount(user);
            return Success("账户禁用成功。");
        }

        /// <summary>
        /// 启用账户
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        [HandlerAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult EnabledAccount(string keyValue)
        {
            SysUser user = new SysUser();
            user.F_Id = keyValue;
            user.F_EnabledMark = true;
            userApp.SetAccount(user);
            return Success("账户启用成功。");
        }

        [HttpGet]
        public ActionResult Info()
        {
            return View();
        }
    }
}
