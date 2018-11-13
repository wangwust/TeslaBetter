using System;
using System.Web.Mvc;

namespace Tesla.Web
{
    /// <summary>
    /// 仅用于处理Ajax请求的特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class HandlerAjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        /// <summary>
        /// 是否可以忽略此特性
        /// </summary>
        public bool Ignore { get; set; }

        public HandlerAjaxOnlyAttribute(bool ignore = false)
        {
            Ignore = ignore;
        }

        public override bool IsValidForRequest(ControllerContext controllerContext, System.Reflection.MethodInfo methodInfo)
        {
            if (Ignore)
                return true;
            return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
        }
    }
}
