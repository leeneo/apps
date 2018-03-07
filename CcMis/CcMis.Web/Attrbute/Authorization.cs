//using CchMis.Common;
using System;
using System.Web;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CcMis.Web.Attrbute
{
    public class Authorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string ip = httpContext.Request.UserHostAddress;
            string superIP = ConfigurationManager.AppSettings["superIP"];
            if (!string.IsNullOrEmpty(superIP))
            {
                string[] super = superIP.Split(';');
                if (super.Contains(ip))
                    return true;
            }
            string allowIP = ConfigurationManager.AppSettings["AllowIP"];
            if (!string.IsNullOrEmpty(allowIP))
            {
                string[] all = allowIP.Split(';');
                if (!all.Contains(ip))
                {
                    LogHelper.Info("非法的IP地址：" + ip);
                    return false;
                }
            }
            string str_token = httpContext.Request.Headers["token"];

            if (string.IsNullOrEmpty(str_token))
            {
                LogHelper.Info("token 不能为空。");
                return false;
            }
            else
            {
                try
                {
                    string key = DateTime.Now.ToString("yyyy#MM#dd");
                    string token = Encryption.AESDecrypt(str_token, key);
                    //if (httpContext.Session["token"] == null)
                    //    return false;
                    //return token == httpContext.Session["token"].ToString();
                    bool flag = token == ConfigurationManager.AppSettings["vcName"];
                    if (!flag)
                    {
                        StringBuilder text = new StringBuilder();
                        text.Append("验证失败：\r\n request token：");
                        text.Append(str_token);
                        text.Append("\r\n request vcName：");
                        text.Append(token);
                        text.Append("\r\nserver vcName:" + ConfigurationManager.AppSettings["vcName"]);
                        text.Append("\r\n IP：");
                        text.Append(httpContext.Request.UserHostAddress);
                        LogHelper.Error(text.ToString());
                    }
                    //ajax跨域处理
                    //httpContext.Response.AddHeader("Access-Control-Allow-Origin", "*");
                    //httpContext.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS,DELETE,PUT");
                    return flag;
                }
                catch (Exception ex)
                {
                    LogHelper.Error("验证token失败：" + str_token + "\r\n" + ex.Message + "\r\n" + ex.StackTrace);
                    return false;
                }
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
            var response = filterContext.HttpContext.Response;
            object obj = new { code = -101, msg = "非法调用" };
            response.ContentEncoding = Encoding.UTF8;
            response.HeaderEncoding = Encoding.UTF8;
            response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }
    }
}