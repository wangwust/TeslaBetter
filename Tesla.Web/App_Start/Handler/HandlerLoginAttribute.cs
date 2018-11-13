using Tesla.Utils;
using System.Web.Mvc;

namespace Tesla.Web
{
    /// <summary>
    /// 校验登录与否
    /// </summary>
    public class HandlerLoginAttribute : AuthorizeAttribute
    {
        public bool Ignore = true;
        public HandlerLoginAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore == false)
            {
                return;
            }

            if (OperatorProvider.Provider.GetCurrent() == null)
            {
                WebHelper.WriteCookie("robo_login_error", "overdue");
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Login/Index';</script>");
            }
        }
    }
}