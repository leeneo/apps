using CCAS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Linq;

namespace CCAS.Filters
{
    public class PMAuthorizeFilter : ActionFilterAttribute, IAuthorizationFilter
    {
        private Db _context { get { return new Db(); } }

        #region 无微信授权时用
        //protected bool IsAuthorized(AuthorizationFilterContext context)
        //{
        //    var httpContext = context.HttpContext;
        //    HttpCookie cookieAccount = new HttpCookie();
        //    cookieAccount.Value = httpContext.Request.Cookies["contactId"];
        //    HttpCookie cookiePwd = new HttpCookie();
        //    cookiePwd.Value = httpContext.Request.Cookies["contactPwd"];
        //    if (cookieAccount == null || string.IsNullOrEmpty(cookieAccount.Value) || cookiePwd == null || string.IsNullOrEmpty(cookiePwd.Value))
        //        return false;
        //    string account = Encryption.AESDecrypt(cookieAccount.Value);
        //    string pwd = Encryption.AESDecrypt(cookiePwd.Value);
        //    User user = null;
        //    PM_Contact con = null;
        //    if (!string.IsNullOrEmpty(httpContext.Session.GetString("PMUser")))
        //    {
        //        var pmUser = httpContext.Session.GetString("PMUser");

        //        if (pmUser is User)
        //        {
        //            user = JsonConvert.DeserializeObject<User>(pmUser);
        //            if (user != null && user.workNo == account && user.Password == pwd)
        //                return true;
        //        }
        //        else if (pmUser is PM_Contact)
        //        {
        //            con = JsonConvert.DeserializeObject<PM_Contact>(pmUser);
        //            if (con != null && con.Contact_TelNo == account && con.password == pwd)
        //                return true;
        //        }
        //    }
        //    SqlParameter[] para = {
        //        new SqlParameter("@workno", account),
        //        new SqlParameter("@pwd",pwd)
        //    };
        //    //user = SQLHelper.ExecuteSqlObject<User>("SELECT * FROM User WHERE workNo=@workno AND Password=@pwd AND IsActive='y'", para);
        //    user = _context.User.FromSql("SELECT * FROM User WHERE workNo=@workno AND Password=@pwd AND IsActive='y'", para).FirstOrDefault();
        //    if (user != null)
        //    {
        //        httpContext.Session.SetString("PMUser", JsonConvert.SerializeObject(user));
        //        return true;
        //    }
        //    //con = SQLHelper.ExecuteSqlObject<PM_Contact>("SELECT * FROM PM_Contact WHERE Contact_TelNo=@tel AND IsActive='y'", new SqlParameter("@tel", account));
        //    con = _context.PM_Contact.FromSql("SELECT * FROM PM_Contact WHERE Contact_TelNo=@tel AND IsActive='y'", new SqlParameter("@tel", account)).FirstOrDefault();
        //    if (con != null)
        //    {
        //        httpContext.Session.SetString("PMUser", JsonConvert.SerializeObject(con));
        //        return true;
        //    }
        //    return false;
        //}
        #endregion

        /// <summary>
        /// 通过微信授权，验证wechatopenid是否有效
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected bool IsAuthorized(AuthorizationFilterContext context)
        {
            var httpContext = context.HttpContext;
            var cookeOpenid = httpContext.Request.Cookies["wechatOpenid"];

            User user = null;
            //PM_Contact con = null;
            SqlParameter[] para = { new SqlParameter("@cookeOpenid", string.IsNullOrWhiteSpace(cookeOpenid) ? "" : cookeOpenid) };
            user = _context.User.FromSql("SELECT * FROM User WHERE wechatid=@cookeOpenid AND IsActive ='Y'", para).FirstOrDefault();
            if (user != null)
            {
                httpContext.Session.SetString("PMUser", JsonConvert.SerializeObject(user));
                return true;
            }
            //con = _context.PM_Contact.FromSql("SELECT u.ContactID,u.CustomerID,u.Contact_Person,u.grouplevel,u.isactive,u.Contact_TelNo,u.Contact_Email,u.Created_user,u.Created_date,u.Audit_User,u.Audit_date,u.password,u.Contact_Email1,u.WeChatID,u.WeChatName" +
            //    " from PM_Contact u left join PM_Customer c on u.CustomerId = c.Customerid where u.isactive = 'Y' and c.IsActive = 'Y' and u.WeChatID=@cookeOpenid", para).FirstOrDefault();
            //if (con != null)
            //{
            //    httpContext.Session.SetString("PMUser", JsonConvert.SerializeObject(con));
            //    return true;
            //}

            return false;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!IsAuthorized(context))
                context.HttpContext.Response.Redirect("/Home/CustomerLogin");
            //throw new System.NotImplementedException();
        }
    }
}