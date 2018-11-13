using Tesla.App;
using Tesla.Utils;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tesla.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        private bool _ignore;

        public HandlerAuthorizeAttribute(bool ignore = true)
        {
           this. _ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(OperatorProvider.Provider == null)
            {
                WebHelper.WriteCookie("robo_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
            }

            if (OperatorProvider.Provider.GetCurrent().IsAdmin)
            {
                return;
            }

            if (!this._ignore)
            {
                return;
            }

            if (!this.ActionAuthorize())
            {
                StringBuilder sbScript = new StringBuilder();
                sbScript.Append("<script type='text/javascript'>alert('很抱歉！您的权限不足，访问被拒绝！');</script>");
                filterContext.Result = new ContentResult() { Content = sbScript.ToString() };
                return;
            }
        }

        /// <summary>
        /// action 权限校验
        /// </summary>
        /// <returns></returns>
        private bool ActionAuthorize()
        {
            var operatorProvider = OperatorProvider.Provider.GetCurrent();
            var roleId = operatorProvider.RoleId;
            var moduleId = WebHelper.GetCookie("robo_currentmoduleid");
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            return new RoleAuthorizeApp().ActionValidate(roleId, moduleId, action);
        }
    }
}