using CCAS.Utils;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CCAS.Filters
{
    public class MyAuthorizeFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            HttpCookie cookieAccount = new HttpCookie();
            cookieAccount.Value = httpContext.Request.Cookies["contactId"];
            if (cookieAccount.Value == null)
                context.HttpContext.Response.Redirect("/Home/Login");
        }
        //public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        //{
        //    await context.HttpContext.Response.WriteAsync($"{GetType().Name} in. \r\n");
        //}
    }
}