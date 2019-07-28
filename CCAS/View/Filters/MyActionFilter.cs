using CCAS.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CCAS.Filters
{
    //ActionFilter
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            HttpCookie cookieAccount = new HttpCookie();
            cookieAccount.Value = httpContext.Request.Cookies["contactId"];
            if (cookieAccount.Value == null)
                context.HttpContext.Response.Redirect("/Home/Login");

            throw new System.NotImplementedException();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var httpContext = context.HttpContext;
            HttpCookie cookieAccount = new HttpCookie();
            cookieAccount.Value = httpContext.Request.Cookies["contactId"];
            if (cookieAccount.Value == null)
                context.HttpContext.Response.Redirect("/Home/Login");

            throw new System.NotImplementedException();
        }
    }
}