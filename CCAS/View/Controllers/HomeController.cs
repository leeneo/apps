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
        /// �ͻ���¼��ʾҳ
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerLogin()
        {
            //_Logger.Info("LogInformation");   //����̨>Web ������>�����LogInformation��
            return View();
        }
        /// <summary>
        /// �ͻ���¼�ύҳ
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
                    return Json(new { success = false, msg = "�˺Ż����벻��Ϊ�ա�" });

                HttpCookie cookieUserType = new HttpCookie();
                HttpCookie cookieOpenID = new HttpCookie();
                cookieOpenID.Value = Request.Cookies["wechatOpenid"];  

                if (cookieUserType.Value == null)
                    cookieUserType.Value = new string("userType");
                if (cookieOpenID.Value == null)
                {
                    cookieOpenID.Value = new string("cookieOpenID");
                    return Json(new { success = false, code = 0, msg = "/home/error?state=��δ��Ȩ��������ת����Ȩ���棡" });
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
                        return Json(new { success = false, msg = "�˺Ż��������" });
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
                    #region ʹ�� BeginTransaction �Ͷ�� DbContext ��ִ�в��Ժ���ʽ����
                    //EF Core ����������Ҫ���ܣ�ʹ���б��� Dapper ���������������ܿ����� ��һ�������Ǵ� LINQ ���ʽת��Ϊ SQL�� ��������Щת������������ˣ��״�ִ������ʱ�Ի���������� �ڶ��������Ƕ�ʵ����и��ĸ��٣��Ա����ɸ�Ч�ĸ�����䣩�� ͨ��ʹ�� AsNotTracking ��չ���ɶ��ض���ѯ�رմ���Ϊ�� EF Core ��������ͨ���ǳ���Ч�� SQL ��ѯ�����Ҵ����ܽǶ��Ͽ����κ�����¶�����ȫ���ܣ��������Ҫִ�жԾ�ȷ��ѯ�ľ�ϸ�����ƣ�Ҳ��ʹ�� EF Core �����Զ��� SQL����ִ�д洢���̣��� ����������£�Dapper ��������Ȼ���� EF Core����ֻ����΢���ơ�
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
                    #region Linq ��������ѯ
                    //var customers = Context.t_Customer.Select(x => x.IsActive == "Y");
                    //var customers2 = Context.t_Customer.Select(b => new t_Customer
                    //{
                    //    Customerid = b.Customerid, //�˴�������ֶ���Ҫ��t_Customer�ж�������֡�����һ�£������Զ����Ϊnull��default value
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
                    //    return Json(new { success = false, msg = "�˺Ż��������" });
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
                return Json(new { success = true, msg = "��¼�ɹ���" });
            }
            catch (Exception ex)
            {
                ex = ex.GetBaseException();
                _Logger.Error(ex.Message, "��������ͻ���¼");
                return Json(new { success = false, msg = "��¼����:" + ex.Message });
            }
        }


        [WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        [tAuthorizeFilter]
        /// <summary>
        /// �ͻ���Ϣ�б�
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


                #region ԭ�� SQL ��ѯ
                //CustomerVm vm = new CustomerVm();
                ////ͨ�� Entity Framework Core ������ʹ�ù�ϵ���ݿ�ʱ�½���ԭʼ SQL ��ѯ�� �����޷�ʹ�� LINQ ���Ҫִ�еĲ�ѯ������ʹ�� LINQ ��ѯ���µ�Ч�� SQL �����͵����ݿ�ʱ�ǳ����á� ԭʼ SQL ��ѯ�ɷ���ʵ������
                ////������е���������������ӳ�䵽������ƥ�䡣 ��ע�⣬���� EF6 ��ͬ��EF6 �к�����ԭʼ SQL ��ѯʱ������/ ��ӳ���ϵ��ֻ��������������������ƥ�伴��
                //vm.customers = Context.t_Customer.FromSql(customer).ToList();
                //vm.systems = Context.t_System.FromSql(system).ToList();
                #endregion

                //vm.types = Context.t_ProjectType.Select(x => new t_ProjectType { Typeid = x.Typeid, TypeCode = x.TypeCode }).ToList();
                //Linq pд��
                //var types = from ty in Context.t_ProjectType select ty;
                //vm.types = types.ToList();
                //ViewBag.UserType = userType;
                //return View(vm);
                return View();
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "��������ҳ��");
                return Json(new { success = false, msg = "��ѯ����:" + ex.Message });
            }
        }
        /// <summary>
        /// �������������Ϣ
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[TypeFilter(typeof(tAuthorizeFilter))]
        //public JsonResult InsertQuestion()
        //{
        //    try
        //    {
                #region �ϴ�ͼƬ
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
        //                    return Json(new { success = false, msg = "ͼƬ�����޶���С��" });
        //                }
        //                else
        //                {
        //                    ImageName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ExtName;//ͼƬ����
        //                    long size = 0;

        //                    //ͼƬ·��  
        //                    //AppDomain.CurrentDomain.BaseDirectory=bin\DebugĿ¼·��
        //                    //hostingEnv.WebRootPath=��վ�µ�wwwrootĿ¼·��
        //                    //var filePath = AppDomain.CurrentDomain.BaseDirectory + "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.logno;
        //                    imgPath = "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.logno;
        //                    filePath = _HostingEnv.WebRootPath + "\\" + imgPath;

        //                    if (!Directory.Exists(filePath))
        //                    {
        //                        Directory.CreateDirectory(filePath);//�����Զ���Ŀ¼
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
        //                return Json(new { success = false, msg = "ͼƬ��ʽ����ȷ��ֻ�����ϴ�jpg,png,gif,jpeg��:" });
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
        /// �˳���¼
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
