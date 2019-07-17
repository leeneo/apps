using CCAS.Filters;
using CCAS.VModels;
using CCAS.VModels.Menus;
using CCAS.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCAS.Controllers
{
    public class TestController : BaseController
    {
        public TestController(IHostingEnvironment env, IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings, IOptions<WxMenus> wxMenus, bool isUseDb = true) : base(env, appSettings, wxSettings, wxMenus, isUseDb) { }

        [WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        public void Test()
        {
            //return "";
        }
        public string CreateMenu()
        {
            var access_token = Request.Cookies["access_token"];
            if (string.IsNullOrWhiteSpace(access_token))
            {
                access_token = "21_v6iof-GkJxpboo_FGywDuRxXpYoqZECLxyGlFqp7sa6FakBIS7GSMU5bMjzFEL9fKMwfxKseWVFU4FGiAy9uBLbv7RlHtDz5BpuyARC4WcbLLzMOI0g9UfsMQOalyGyc9RMy4nWKgN5qiDI1HJKiAHAACD";
                //return "access_token Îª¿Õ£¡";
            }
            _Logger.Info(access_token);
            var url = $"https://api.weixin.qq.com/cgi-bin/menu/create?access_token={access_token}";
            //ApiClient.Post(url, _WxMenus.Value.Data);
            //return JsonConvert.SerializeObject(_WxMenus.Value.Data);
            var res = ApiClient.Post(url, _WxMenus.Value.Body);

            _Logger.Info("postUrl:" + url + ";res:" + res);

            return res;
        }

        public Data Menus()
        {
            var res = _WxMenus.Value.Body;
            return res;
        }
        //public Menu[] Menus()
        //{
        //    var res = _WxMenus.Value.button;
        //    return res;
        //}

        public ActionResult Index()
        {
            Response.Cookies.Append("test", "YYYY", new CookieOptions()
            {
                Expires = DateTime.Now.AddMonths(3),
                IsEssential = true
            });
            var obj = Request.Cookies.Keys;

            return View();
        }
        public string GetOpenid()
        {
            var obj = Request.Cookies["wechatOpenid"];

            return obj;
        }
        public WxSettings Base()
        {
            var _settings = new WxOptions(_WxSettings);
            return _settings.Value;
        }

        public string Log()
        {
            _Logger.Info("LogInformation");
            _Logger.Error("TTTTÖÐÎÄ²âÊÔ");
            return _Logger.ToString();
        }

        public string MyLog()
        {
            var loger = new MyLogger("Info");
            var ex = new Exception("eeeee");
            loger.Info("MyLog", ex);
            return loger.ToString();
        }

        public void Write()
        {
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf21b621842e5764f&redirect_uri=http%3A%2F%2Fmp.ccspa168.com%2FOAuth2%2FUserInfoCallback&response_type=code&scope=snsapi_userinfo&state=&connect_redirect=1#wechat_redirect";
            var res = ApiClient.Get(url);
            _Logger.Info(res);
            Response.WriteAsync(res, Encoding.GetEncoding("GB2312"));
            Response.Body.FlushAsync();
            Response.Body.Close();
        }
        public void WriteBytes()
        {
            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf21b621842e5764f&redirect_uri=http%3A%2F%2Fmp.ccspa168.com%2FOAuth2%2FUserInfoCallback&response_type=code&scope=snsapi_userinfo&state=&connect_redirect=1#wechat_redirect";
            var res = ApiClient.GetBytes(url);
            Response.Body.Write(res);
            Response.Body.FlushAsync();
            Response.Body.Close();
        }
        public void getWxCode()
        {
            string url = $"{_WxSettings.Value.AuthorizeUrl}appid=wxf21b621842e5764f&redirect_uri={_WxSettings.Value.OAuth2_URL}&response_type=code&scope=snsapi_userinfo&state=LEENEO.CN&connect_redirect=1#wechat_redirect";
            Response.Redirect(url);
            Response.Body.FlushAsync();
            Response.Body.Close();
        }
    }
}
