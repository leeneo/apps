using CCAS.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;

namespace CCAS.Controllers
{
    public class OAuth2Controller : BaseController
    {
        public OAuth2Controller(IOptions<WxSettings> wxSettings) : base(wxSettings) { }

        /// <summary>
        /// OAuthScope.snsapi_userinfo方式回调
        /// </summary>
        /// <param name="code"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ActionResult UserInfoCallback(string code, string state)
        {
            if (string.IsNullOrEmpty(code))
            {
                return Content("您拒绝了授权！");
            }
            OAuthAccessTokenResult result = null;

            //通过，用code换取access_token
            try
            {
                _Logger.Info("code:"+code, "OAuth2Controller");
                if (_WxSettings.Value.IsDebug == "true")
                {
                    result = new OAuthAccessTokenResult();
                    result.openid = "o-4S_jjslMSlHp7wPDSTxhear0WA";
                    result.access_token = "wxf21b621842e5764f533b4df502cc9aac0d94f71f4e0a2c84wxf21b621842e5764f533b4df502cc9aac0d94f71f4e0a2c84";
                }
                else
                    result = OAuthApi.GetAccessToken("wx039fe6f6510afda2", "16b0f79d4c12a73fb0010d7c07479526", code);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
            if (result.errcode != ReturnCode.请求成功)
            {
                return Content("错误：" + result.errmsg);
            }
            //下面2个数据也可以自己封装成一个类，储存在数据库中（建议结合缓存）
            //如果可以确保安全，可以将access_token存入用户的cookie中，每一个人的access_token是不一样的
            //Session["OAuthAccessTokenStartTime"] = DateTime.Now;
            //Session["OAuthAccessToken"] = result;

            //因为第一步选择的是OAuthScope.snsapi_userinfo，这里可以进一步获取用户详细信息
            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(result.access_token, result.openid);
                _Logger.Info("result.openid:" + result.openid + "}", "OAuth2Controller");
                _Logger.Info("userInfo.nickname:" + userInfo.nickname + "}", "OAuth2Controller");
                _Logger.Info("userInfo.headimgurl:" + userInfo.headimgurl + "}", "OAuth2Controller");
                _Logger.Info("userInfo.sex:" + userInfo.sex + "}", "OAuth2Controller");
                _Logger.Info("access_token:" + result.access_token + "}", "OAuth2Controller");

                Response.Cookies.Append("wechatOpenid", result.openid, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true  //声明为必要的，以使在浏览器可见，即使CookiePolicyOptions.CheckConsentNeeded为false的情况下
                });
                Response.Cookies.Append("nickname", userInfo.nickname, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true  //声明为必要的，以使在浏览器可见，即使CookiePolicyOptions.CheckConsentNeeded为false的情况下
                });
                Response.Cookies.Append("headimgurl", userInfo.headimgurl, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true  //声明为必要的，以使在浏览器可见，即使CookiePolicyOptions.CheckConsentNeeded为false的情况下
                });
                Response.Cookies.Append("sex", Convert.ToString(userInfo.sex), new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true  //声明为必要的，以使在浏览器可见，即使CookiePolicyOptions.CheckConsentNeeded为false的情况下
                });
                Response.Cookies.Append("access_token", result.access_token, new CookieOptions()
                {
                    Expires = DateTime.Now.AddHours(2),
                    IsEssential = true  //声明为必要的，以使在浏览器可见，即使CookiePolicyOptions.CheckConsentNeeded为false的情况下
                });

                //var item = ApiClient.GetMemberInfo(userInfo.openid);
                //if (item != null)
                //{
                //    cookieOperate.WeChatOpenId = item.WeChatOpenId;
                //    cookieOperate.MemberID = item.MemberID;
                //    if (string.IsNullOrEmpty(item.LogoUrl))
                //    {
                //        item.LogoUrl = userInfo.headimgurl;
                //ApiClient.UpdateToMain(item);
                //    }
                //}
                //else
                //{
                //    var memberInfo = new MemberInfo
                //    {
                //        //MemberID = Int32.Parse(Model.MemberID.Trim()),
                //        MemberName = Server.UrlEncode(userInfo.nickname),
                //        Password = "",
                //        Gender = userInfo.sex == 1 ? "M" : "F",
                //        TelNumber = "",
                //        RegisterTime = DateTime.Now,
                //        Use_TJ_code = "",
                //        WeChatOpenId = userInfo.openid,
                //        LogoUrl = userInfo.headimgurl
                //    };
                //cookieOperate.WeChatOpenId = memberInfo.WeChatOpenId;
                //cookieOperate.MemberID = memberInfo.MemberID;
                //cookieOperate.UserPhoto = userInfo.headimgurl;
                //if (ApiClient.Update(memberInfo))
                //    _Logger.Info("更新用户信息成功", JsonConvert.SerializeObject(memberInfo));
                //else
                //    _Logger.Info("更新用户信息失败", JsonConvert.SerializeObject(memberInfo));
                //}
                //if (Session["QRCodeLogin"].ToString() == "true")
                //{
                //    return Json(new { success=true,});
                //}
                //string url = Session["retUrl"] == null ? "/CCIndex/Index" : Session["retUrl"].ToString();
                return RedirectToAction("CustomerLogin", "Home");
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                _Logger.Error(ex.Message);
                return Content(ex.Message);
            }
        }
    }
}
