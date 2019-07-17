using CCAS.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using NLog;
using System;

namespace CCAS.Filters
{
    public class WeChatAuthorizeAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private ILogger _logger { get { return LogManager.GetLogger("CCAS"); } set {; } }
        private Db _context { get { return new Db(); } set {; } }

        public string AuthorizeUrl { get; set; }
        public string OAuth2_URL { get; set; }

        //public WeChatAuthorizeAttribute()
        //{
        //    _logger = LogManager.GetLogger("CCAS");
        //}
        protected bool IsAuthorized(AuthorizationFilterContext context)
        {
            try
            {
                //return true;
                var httpContext = context.HttpContext;

                var cookeOpenid = httpContext.Request.Cookies["wechatOpenid"];
                if (!string.IsNullOrWhiteSpace(cookeOpenid))
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
                _logger.Error(ex.Message);
                return false;
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //_logger.Info("AuthorizeUrl:" + AuthorizeUrl + " ,OAuth2_URL:" + OAuth2_URL, "WeChatAuthorizeAttribute");

            //var redirectUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf21b621842e5764f&redirect_uri=http://ccas.leeneo.com/OAuth2/UserInfoCallback&response_type=code&scope=snsapi_userinfo&state=&connect_redirect=1#wechat_redirect";

            var redirectUrl = $"{AuthorizeUrl}appid=wx039fe6f6510afda2&redirect_uri={OAuth2_URL}&response_type=code&scope=snsapi_userinfo&state=LEENEO.CN&connect_redirect=1#wechat_redirect";

            if (!IsAuthorized(context))
                context.HttpContext.Response.Redirect(redirectUrl);
        }
    }
}