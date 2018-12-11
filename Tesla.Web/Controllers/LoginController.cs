using System;
using System.Web.Mvc;
using Tesla.Model;
using Tesla.Utils;
using Tesla.App;

namespace Tesla.Web.Controllers
{
    public sealed class LoginController : Controller
    {
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            var test = string.Format("{0:E2}", 1);
            return View();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new SysLog
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });

            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult CheckLogin(string username, string password, string code)
        {
            SysLog sysLog = new SysLog
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Login.ToString()
            };

            try
            {
                //if (Session["robo_session_verifycode"].IsEmpty() || Md5Helper.Md5(code.ToLower(), 16) != Session["robo_session_verifycode"].ToString())
                //{
                //    throw new Exception("验证码错误，请重新输入");
                //}

                SysUser userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    PresentUser operatorModel = new PresentUser
                    {
                        UserId = userEntity.F_Id,
                        UserCode = userEntity.F_Account,
                        UserName = userEntity.F_RealName,
                        CompanyId = userEntity.F_OrganizeId,
                        DepartmentId = userEntity.F_DepartmentId,
                        RoleId = userEntity.F_RoleId,
                        LoginIPAddress = NetHelper.Ip
                    };
                    //operatorModel.LoginIPAddressName = NetHelper.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESHelper.Encrypt(Guid.NewGuid().ToString());

                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsAdmin = true;
                    }
                    else
                    {
                        operatorModel.IsAdmin = false;
                    }

                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    sysLog.F_Account = userEntity.F_Account;
                    sysLog.F_NickName = userEntity.F_RealName;
                    sysLog.F_Result = true;
                    sysLog.F_Description = "登录成功";
                    new LogApp().WriteDbLog(sysLog);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                sysLog.F_Account = username;
                sysLog.F_NickName = username;
                sysLog.F_Result = false;
                sysLog.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(sysLog);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }
    }
}
