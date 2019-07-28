using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.AspNetCore.Mvc;
using CCAS.Models;
using Microsoft.AspNetCore.Http;
using CCAS.Utils;
using MD5 = CCAS.Utils.MD5;
using Microsoft.EntityFrameworkCore;
using CCAS.VModels;
using Microsoft.AspNetCore.Hosting;
using CCAS.Filters;
using Microsoft.Extensions.Options;

namespace CCAS.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHostingEnvironment env, IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings, bool isUseDb = true)
            : base(env, appSettings, wxSettings, isUseDb) { }

        [WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        /// <summary>
        /// 客户登录显示页
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerLogin()
        {
            //_Logger.Info("LogInformation");   //控制台>Web 服务器>输出“LogInformation”
            return View();
        }
        /// <summary>
        /// 客户登录提交页
        /// </summary>
        /// <returns></returns>
        public ActionResult PostCustomerLogin()
        {
            try
            {
                string account = Request.Form["account"];
                string pwd = Request.Form["pwd"];
                string typeUser = Request.Form["cbxUser"];
                string userName = "";

                if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(pwd))
                    return Json(new { success = false, msg = "账号或密码不能为空。" });

                HttpCookie cookieUserType = new HttpCookie();
                HttpCookie cookieOpenID = new HttpCookie();
                cookieOpenID.Value = Request.Cookies["wechatOpenid"];  

                if (cookieUserType.Value == null)
                    cookieUserType.Value = new string("userType");
                if (cookieOpenID.Value == null)
                {
                    cookieOpenID.Value = new string("cookieOpenID");
                    return Json(new { success = false, code = 0, msg = "/home/error?state=尚未授权，即将跳转到授权界面！" });
                }

                if (typeUser == "Y")
                {
                    #region Banned
                    //sql = "SELECT * FROM User WHERE workNo=@loginNo AND [Password]=@password AND IsActive='y'";
                    //SqlParameter[] param = new SqlParameter[]
                    //{
                    //    new SqlParameter("@loginNo",account),
                    //    new SqlParameter("@password",pwd),
                    //};
                    #endregion

                    User user = Context.User.FirstOrDefault(x => x.workNo == account && x.Password == pwd && x.IsActive == "Y");
                    if (user == null)
                        return Json(new { success = false, msg = "账号或密码错误。" });
                    user.WeChatID = cookieOpenID.Value;
                    Context.User.Update(user);
                    Context.SaveChanges();

                    cookieUserType.Value = typeUser;
                    userName = Encryption.AESEncrypt(user.UserName);
                }
                else
                {
                    pwd = account.ToLower() == "leeneo" ? pwd : MD5.GetMd5Str32(pwd);

                    #region Banned
                    //sql = "SELECT * from user u left join t_Customer c on u.CustomerId = c.Customerid where u.isactive = 'Y' and c.IsActive = 'Y' and u.Contact_TelNo =@loginNo  and u.[password] = @password; ";

                    //SqlParameter[] param = new SqlParameter[]
                    //{
                    //    new SqlParameter("@loginNo",account),
                    //    new SqlParameter("@password",pwd),
                    //};
                    //SQLHelper.SetConnection("tDb");
                    //user contact = SQLHelper.ExecuteSqlObject<user>(sql, param);
                    #endregion
                    #region 使用 BeginTransaction 和多个 DbContext 的执行策略和显式事务。
                    //EF Core 具有两个重要功能，使其有别于 Dapper ，并且增加其性能开销。 第一个功能是从 LINQ 表达式转换为 SQL。 将缓存这些转换，但即便如此，首次执行它们时仍会产生开销。 第二个功能是对实体进行更改跟踪（以便生成高效的更新语句）。 通过使用 AsNotTracking 扩展，可对特定查询关闭此行为。 EF Core 还会生成通常非常高效的 SQL 查询，并且从性能角度上看，任何情况下都能完全接受，但如果需要执行对精确查询的精细化控制，也可使用 EF Core 传入自定义 SQL（或执行存储过程）。 在这种情况下，Dapper 的性能仍然优于 EF Core，但只有略微优势。
                    ////var strategy = Context.Database.CreateExecutionStrategy();
                    //await strategy.ExecuteAsync(async () =>
                    //{
                    //    // Achieving atomicity between original Catalog database operation and the
                    //    // IntegrationEventLog thanks to a local transaction
                    //    using (var transaction = Context.Database.BeginTransaction())
                    //    {
                    //        Context.user.Update(contact);
                    //        await Context.SaveChangesAsync();

                    //        // Save to EventLog only if product price changed
                    //        //if (raiseProductPriceChangedEvent)
                    //        //    await _integrationEventLogService.SaveEventAsync(priceChangedEvent);
                    //        transaction.Commit();
                    //    }
                    //});
                    #endregion
                    #region Linq 带条件查询
                    //var customers = Context.t_Customer.Select(x => x.IsActive == "Y");
                    //var customers2 = Context.t_Customer.Select(b => new t_Customer
                    //{
                    //    Customerid = b.Customerid, //此处定义的字段名要与t_Customer中定义的名字、个数一致，否则自动填充为null或default value
                    //    CustomerName = b.CustomerName,
                    //    IsActive = b.IsActive,
                    //    //Validdate=b.Validdate,
                    //    status = b.status
                    //});
                    #endregion

                    //var contactLq = from tcn in Context.user
                    //                .Where(x => x.isactive == "Y" && x.Contact_TelNo == account && x.password == pwd)
                    //                join tcu in Context.t_Customer
                    //                .Where(x => x.IsActive == "Y")
                    //                on tcn.CustomerID equals tcu.Customerid into temp2
                    //                from tm2 in temp2.DefaultIfEmpty()
                    //                select tcn;
                    //user contact = contactLq.FirstOrDefault();

                    //if (contact == null)
                    //    return Json(new { success = false, msg = "账号或密码错误。" });
                    //contact.WeChatID = cookieOpenID.Value;
                    //Context.user.Update(contact);
                    //Context.SaveChanges();

                    //cookieAccount.Value = Encryption.AESEncrypt(contact.Contact_TelNo);
                    //cookiePwd.Value = Encryption.AESEncrypt(contact.password);
                    //cookieUserType.Value = "";
                    //cookieID.Value = contact.ContactID.ToString();
                    //userName = Encryption.AESEncrypt(contact.Contact_Person);

                    //Response.Cookies.Append("CustomerID", contact.CustomerID.ToString(), new CookieOptions()
                    //{
                    //    Expires = DateTime.Now.AddMonths(3),
                    //    IsEssential = true
                    //});
                Response.Cookies.Append("UserName", userName, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true
                });
                return Json(new { success = true, msg = "登录成功。" });
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                _Logger.Error(ex.Message, "新增问题客户登录");
                return Json(new { success = false, msg = "登录出错:" + ex.Message });
            }
        }


        [WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        [tAuthorizeFilter]
        /// <summary>
        /// 客户信息列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(string txtName)
        {
            int customerId;
            int.TryParse(txtName, out customerId);
            var cookieAccount = Request.Cookies["contactId"];
            var cookieID = Request.Cookies["contactUserId"];
            var userType = Request.Cookies["userType"];
            var CustomerID = Request.Cookies["CustomerID"];


            try
            {
                string customer = "";
                string system = "";


                #region 原生 SQL 查询
                //CustomerVm vm = new CustomerVm();
                ////通过 Entity Framework Core 可以在使用关系数据库时下降到原始 SQL 查询。 这在无法使用 LINQ 表达要执行的查询，或因使用 LINQ 查询导致低效的 SQL 被发送到数据库时非常有用。 原始 SQL 查询可返回实体类型
                ////结果集中的列名必须与属性映射到的列名匹配。 请注意，这与 EF6 不同，EF6 中忽略了原始 SQL 查询时的属性/ 列映射关系，只需结果集列名与属性名相匹配即可
                //vm.customers = Context.t_Customer.FromSql(customer).ToList();
                //vm.systems = Context.t_System.FromSql(system).ToList();
                #endregion

                //vm.types = Context.t_ProjectType.Select(x => new t_ProjectType { Typeid = x.Typeid, TypeCode = x.TypeCode }).ToList();
                //Linq p写法
                //var types = from ty in Context.t_ProjectType select ty;
                //vm.types = types.ToList();
                //ViewBag.UserType = userType;
                //return View(vm);
                return View();
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "进入新增页面");
                return Json(new { success = false, msg = "查询出错:" + ex.Message });
            }
        }
        /// <summary>
        /// 添加问题描述信息
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[TypeFilter(typeof(tAuthorizeFilter))]
        //public JsonResult InsertQuestion()
        //{
        //    try
        //    {
                #region 上传图片
        //        var ImageName = "";
        //        var filePath = "";
        //        var imgPath = "";
        //        var imgFile = Request.Form.Files["img"];

        //        if (null != imgFile && !string.IsNullOrEmpty(imgFile.FileName))
        //        {
        //            string ExtName = Path.GetExtension(imgFile.FileName).ToLower();
        //            if (ExtName == ".jpg" || ExtName == ".jpeg" || ExtName == ".png" || ExtName == ".gif")
        //            {
        //                if (imgFile.Length / 1024 > 1024)
        //                {
        //                    return Json(new { success = false, msg = "图片超过限定大小！" });
        //                }
        //                else
        //                {
        //                    ImageName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ExtName;//图片名称
        //                    long size = 0;

        //                    //图片路径  
        //                    //AppDomain.CurrentDomain.BaseDirectory=bin\Debug目录路径
        //                    //hostingEnv.WebRootPath=网站下的wwwroot目录路径
        //                    //var filePath = AppDomain.CurrentDomain.BaseDirectory + "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.logno;
        //                    imgPath = "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.logno;
        //                    filePath = _HostingEnv.WebRootPath + "\\" + imgPath;

        //                    if (!Directory.Exists(filePath))
        //                    {
        //                        Directory.CreateDirectory(filePath);//创建自定义目录
        //                    }

        //                    var uploadFolder = filePath + $@"\{ImageName}";
        //                    size += imgFile.Length;
        //                    using (FileStream fs = System.IO.File.Create(uploadFolder))
        //                    {
        //                        imgFile.CopyTo(fs);
        //                        fs.Flush();
        //                    }
        //                }
        //            }
        //            else
        //                return Json(new { success = false, msg = "图片格式不正确，只允许上传jpg,png,gif,jpeg！:" });
        //        }
        #endregion

        //}




        public JsonResult UserList()
        {
            List<User> list = Context.User.ToList();
            return Json(list);
        }
        public JsonResult ActiveUserList()
        {
            List<User> list = Context.User.Where(x => x.IsActive == "Y").ToList();
            return Json(list);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Exit()
        {
            DateTime time = DateTime.Now.AddDays(-1);
            Response.Cookies.Delete("wechatOpenid");
            return Redirect(Url.Content("~/Home/CustomerLogin"));
        }
        public string moreQuestions(int? index, int? size)
        {
            if (!index.HasValue || !size.HasValue)
                return JsonConvert.SerializeObject(new { success = true, data = "" });
            IsoDateTimeConverter format = new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm" };
            string id = null;
            if (Request.Cookies["cid"] != null)
                id = Request.Cookies["cid"];
            return JsonConvert.SerializeObject(new { success = true, data = GetQuestions(index.Value, size.Value, id) }, format);
        }
        private List<Project> GetQuestions(int index, int size, string id)
        {
            string sql = @"";
            if (string.IsNullOrEmpty(id))
            {
                sql += " ";
                //return db.Database.SqlQuery<Project>(sql, new SqlParameter("@user", account)).Skip(index * size).Take(size).ToList();
                return CCAS.Utils.SqlHelper.SqlQuery<Project>(Context, sql, new SqlParameter("@user", Encryption.AESDecrypt(Request.Cookies["contactId"]))).Skip(index * size).Take(size).ToList();
            }
            else
            {
                sql += " ";
                //return db.Database.SqlQuery<Project>(sql, new SqlParameter("@id", id)).Skip(index * size).Take(size).ToList();
                return CCAS.Utils.SqlHelper.SqlQuery<Project>(Context, sql, new SqlParameter("@id", id)).Skip(index * size).Take(size).ToList();
            }
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
