using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB
{
    public class Authorization : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AppContext.isLoginIn())
            {
                if (filterContext.HttpContext.Request.IsAjaxRequest() || filterContext.IsChildAction)
                    filterContext.Result = JsonResponce.New(false, "请先登录", 1).AsJsonResult();
                else
                {
                    var url = new UrlHelper(filterContext.RequestContext);
                    filterContext.Result = new RedirectResult(url.Action("Login", "User", new { returnUrl = filterContext.HttpContext.Request.Url }));
                }
            }
        }
    }
}