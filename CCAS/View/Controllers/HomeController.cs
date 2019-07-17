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

                HttpCookie cookieAccount = new HttpCookie();
                HttpCookie cookiePwd = new HttpCookie();
                HttpCookie cookieUserType = new HttpCookie();
                HttpCookie cookieID = new HttpCookie();
                HttpCookie cookieOpenID = new HttpCookie();
                cookieAccount.Value = Request.Cookies["contactId"]; //���ܵ� PM_Contact.Contact_TelNo����User.workNo
                cookiePwd.Value = Request.Cookies["contactPwd"];
                cookieUserType.Value = Request.Cookies["userType"];
                cookieID.Value = Request.Cookies["contactUserId"];  //PM_Contact.ContactID����User.workNo
                cookieOpenID.Value = Request.Cookies["wechatOpenid"];  //PM_Contact.ContactID����User.workNo

                if (cookieAccount.Value == null)
                    cookieAccount.Value = new string("contactId");
                if (cookiePwd.Value == null)
                    cookiePwd.Value = new string("contactPwd");
                if (cookieUserType.Value == null)
                    cookieUserType.Value = new string("userType");
                if (cookieID.Value == null)
                    cookieID.Value = new string("contactUserId");
                if (cookieOpenID.Value == null)
                {
                    cookieOpenID.Value = new string("cookieOpenID");
                    return Json(new { success = false, code = 0, msg = "/home/error?state=��δ��Ȩ��������ת����Ȩ���棡" });
                }

                if (typeUser == "Y")
                {
                    #region Banned
                    //sql = "SELECT * FROM User WHERE workNo=@loginNo AND [Password]=@password AND IsActive='y' --AND DeptCode='kf' ";
                    //SqlParameter[] param = new SqlParameter[]
                    //{
                    //    new SqlParameter("@loginNo",account),
                    //    new SqlParameter("@password",pwd),
                    //};
                    //SQLHelper.SetConnection("PmDb");
                    #endregion

                    User user = Context.User.FirstOrDefault(x => x.workNo == account && x.Password == pwd && x.IsActive == "Y");
                    if (user == null)
                        return Json(new { success = false, msg = "�˺Ż��������" });
                    user.WeChatID = cookieOpenID.Value;
                    Context.User.Update(user);
                    Context.SaveChanges();

                    cookieUserType.Value = typeUser;
                    cookiePwd.Value = Encryption.AESEncrypt(user.Password);
                    cookieID.Value = user.workNo;
                    cookieAccount.Value = Encryption.AESEncrypt(user.workNo);
                    userName = Encryption.AESEncrypt(user.UserName);
                }
                else
                {
                    pwd = account.ToLower() == "sys" ? pwd : MD5.GetMd5Str32(pwd);

                    #region Banned
                    //sql = "SELECT * from PM_Contact u left join PM_Customer c on u.CustomerId = c.Customerid where u.isactive = 'Y' and c.IsActive = 'Y' and u.Contact_TelNo =@loginNo  and u.[password] = @password; ";

                    //SqlParameter[] param = new SqlParameter[]
                    //{
                    //    new SqlParameter("@loginNo",account),
                    //    new SqlParameter("@password",pwd),
                    //};
                    //SQLHelper.SetConnection("PmDb");
                    //PM_Contact contact = SQLHelper.ExecuteSqlObject<PM_Contact>(sql, param);
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
                    //        Context.PM_Contact.Update(contact);
                    //        await Context.SaveChangesAsync();

                    //        // Save to EventLog only if product price changed
                    //        //if (raiseProductPriceChangedEvent)
                    //        //    await _integrationEventLogService.SaveEventAsync(priceChangedEvent);
                    //        transaction.Commit();
                    //    }
                    //});
                    #endregion
                    #region Linq ��������ѯ
                    //var customers = Context.PM_Customer.Select(x => x.IsActive == "Y");
                    //var customers2 = Context.PM_Customer.Select(b => new PM_Customer
                    //{
                    //    Customerid = b.Customerid, //�˴�������ֶ���Ҫ��PM_Customer�ж�������֡�����һ�£������Զ����Ϊnull��default value
                    //    CustomerName = b.CustomerName,
                    //    IsActive = b.IsActive,
                    //    //Validdate=b.Validdate,
                    //    status = b.status
                    //});
                    #endregion

                    //var contactLq = from pmcn in Context.PM_Contact
                    //                .Where(x => x.isactive == "Y" && x.Contact_TelNo == account && x.password == pwd)
                    //                join pmcu in Context.PM_Customer
                    //                .Where(x => x.IsActive == "Y")
                    //                on pmcn.CustomerID equals pmcu.Customerid into temp2
                    //                from tm2 in temp2.DefaultIfEmpty()
                    //                select pmcn;
                    //PM_Contact contact = contactLq.FirstOrDefault();

                    //if (contact == null)
                    //    return Json(new { success = false, msg = "�˺Ż��������" });
                    //contact.WeChatID = cookieOpenID.Value;
                    //Context.PM_Contact.Update(contact);
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
                }
                Response.Cookies.Append("contactId", cookieAccount.Value, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true  //����Ϊ��Ҫ�ģ���ʹ��������ɼ�����ʹCookiePolicyOptions.CheckConsentNeededΪfalse�������
                });
                Response.Cookies.Append("contactPwd", cookiePwd.Value, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true
                });
                Response.Cookies.Append("userType", cookieUserType.Value, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true
                });
                Response.Cookies.Append("contactUserId", cookieID.Value, new CookieOptions()
                {
                    Expires = DateTime.Now.AddMonths(3),
                    IsEssential = true
                });
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

        /// <summary>
        /// ��ȡ�ͻ���Ϣ�б�
        /// </summary>
        /// <returns></returns>
        //[WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        //[PMAuthorizeFilter]
        //public ActionResult GetCustomerInfoList()
        //{
        //    _WxSettings.Value.AuthorizeUrl = "";

        //    CustomerVm vm = new CustomerVm();
        //    string user = "";
        //    if (!string.IsNullOrWhiteSpace(Request.Query["txtName"]))
        //        user = Request.Query["txtName"];
        //    vm.customers = GetCustomers(0, 25, user);
        //    return View(vm);
        //}
        //public string GetMoreCustomers(int? index, int? size, string user)
        //{
        //    if (index.HasValue && size.HasValue)
        //    {
        //        IsoDateTimeConverter format = new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm" };
        //        return JsonConvert.SerializeObject(new { success = true, data = GetCustomers(index.Value, size.Value, user) }, format);
        //    }
        //    return JsonConvert.SerializeObject(new { success = true, data = string.Empty });
        //}

        [WeChatAuthorize(AuthorizeUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?", OAuth2_URL = "http://ccas.leeneo.com/OAuth2/UserInfoCallback")]
        [PMAuthorizeFilter]
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

            if (string.IsNullOrWhiteSpace(cookieAccount) || string.IsNullOrWhiteSpace(cookieID))
                return Redirect(Url.Content("~/Home/CustomerLogin"));
            else if (userType == "Y" && customerId <= 0)
                return Redirect(Url.Content("~/Home/GetCustomerInfoList"));

            try
            {
                string customer = "";
                string system = "";

                if (userType == "Y")
                {
                    customer = "  SELECT cr.Customerid,cr.CustomerName,cr.[status],cr.Validdate,cr.IsActive FROM PM_Customer cr WHERE 1 = 1 order by cr.CustomerName  ";
                    system = " select s.systemid,s.systemname from PM_Customer_System c left join PM_System s on c.systemid = s.systemid where c.customerid = " + customerId;
                    ViewBag.CustomerID = customerId;
                }
                else
                {
                    customer = " SELECT cr.Customerid,cr.CustomerName,cr.[status],cr.Validdate,cr.IsActive FROM PM_Contact ct LEFT JOIN PM_Customer cr ON ct.CustomerID = cr.Customerid WHERE 1 = 1 AND ct.Contact_TelNo = '" + Encryption.AESDecrypt(cookieAccount) + "'";
                    system = "select st.systemid,st.systemname from PM_Customer_System cs left join PM_System st on cs.systemid = st.systemid left join PM_Contact ct on cs.customerid = ct.CustomerID where ct.ContactID = " + cookieID;
                    ViewBag.CustomerID = Convert.ToInt32(CustomerID);
                }

                #region ԭ�� SQL ��ѯ
                //CustomerVm vm = new CustomerVm();
                ////ͨ�� Entity Framework Core ������ʹ�ù�ϵ���ݿ�ʱ�½���ԭʼ SQL ��ѯ�� �����޷�ʹ�� LINQ ���Ҫִ�еĲ�ѯ������ʹ�� LINQ ��ѯ���µ�Ч�� SQL �����͵����ݿ�ʱ�ǳ����á� ԭʼ SQL ��ѯ�ɷ���ʵ������
                ////������е���������������ӳ�䵽������ƥ�䡣 ��ע�⣬���� EF6 ��ͬ��EF6 �к�����ԭʼ SQL ��ѯʱ������/ ��ӳ���ϵ��ֻ��������������������ƥ�伴��
                //vm.customers = Context.PM_Customer.FromSql(customer).ToList();
                //vm.systems = Context.PM_System.FromSql(system).ToList();
                #endregion

                //vm.types = Context.PM_ProjectType.Select(x => new PM_ProjectType { Typeid = x.Typeid, TypeCode = x.TypeCode }).ToList();
                //Linq pд��
                //var types = from ty in Context.PM_ProjectType select ty;
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
        //[TypeFilter(typeof(PMAuthorizeFilter))]
        //public JsonResult InsertQuestion()
        //{
        //    try
        //    {
        //        string customerid = Request.Form["selCustomerName"];
        //        var hasDb = Request.Form["dals"];
        //        var creatUser = Request.Cookies["contactUserId"];
        //        var userName = Encryption.AESDecrypt(Request.Cookies["UserName"]);

        //        PM_Contact contact = new PM_Contact();
        //        PM_Attachment attachment = new PM_Attachment();
        //        User pmUser = new User();

        //        string project = "SELECT TOP 1 ProjectID,ProjectNo,ProjectTypeid,Systemtypeid,Customerid,ProjectDesc,Status,modifycount,IsUrgent,Assigned_user,AplicateUser,Created_user,Created_date,Audit_user,Audit_date,Time_cost,s_code,Is_Database,Assigned_to FROM PM_Project WHERE ProjectNo < CONVERT(varchar,8*10000) ORDER BY ProjectNo DESC";
        //        //var pro = leeneo.Common.SQLHelper.ExecuteSqlObject<PM_Project>(project);
        //        var pro = Context.PM_Project.FromSql(project).FirstOrDefault();
        //        var proj = new PM_Project()
        //        {
        //            ProjectNo = (int.Parse(pro.ProjectNo) + 1).ToString(),
        //            ProjectTypeid = Convert.ToDecimal(Request.Form["types"]),
        //            Systemtypeid = Convert.ToDecimal(Request.Form["systems"]),
        //            Customerid = Convert.ToDecimal(customerid),
        //            ProjectDesc = Request.Form["issue"].ToString(),
        //            Status = "O",
        //            modifycount = 0,
        //            IsUrgent = "N",
        //            Assigned_to = "",
        //            Assigned_user = "",
        //            Audit_user = creatUser,
        //            Created_user = creatUser,
        //            AplicateUser = userName,
        //            Audit_date = DateTime.Now,
        //            Created_date = DateTime.Now,
        //            Time_cost = 0.5M,
        //            s_code = Request.Form["models"].ToString(),
        //            Is_Database = !string.IsNullOrWhiteSpace(hasDb) && hasDb == "true" ? "Y" : "N"
        //        };
        //        var userType = Request.Cookies["userType"];
        //        if (userType == "Y")
        //        {
        //            proj.Assigned_user = creatUser;
        //            proj.Assigned_to = creatUser;
        //        }
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
        //                    //var filePath = AppDomain.CurrentDomain.BaseDirectory + "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.ProjectNo;
        //                    imgPath = "Attachs\\" + customerid + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + proj.ProjectNo;
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

        //        Context.PM_Project.Add(proj);
        //        int result = Context.SaveChanges();
        //        if (result > 0)
        //        {
        //            if (null != imgFile && !string.IsNullOrEmpty(imgFile.FileName))
        //            {
        //                //string projectId = "select top 1 * from PM_Project where Created_date=(select max(Created_date) from PM_Project)";
        //                //pro = leeneo.Common.SQLHelper.ExecuteSqlObject<PM_Project>(projectId);
        //                //pro = Context.PM_Project.FromSql(projectId).FirstOrDefault();

        //                attachment.ProjectID = proj.ProjectID;
        //                attachment.AttachName = ImageName;
        //                attachment.Filepath = imgPath + "\\" + ImageName;
        //                attachment.Created_user = proj.Created_user;
        //                attachment.Created_date = DateTime.Now;
        //                attachment.Audit_user = proj.Audit_user;
        //                attachment.Audit_date = DateTime.Now;

        //                string sqlAdd = "INSERT INTO PM_Attachment(ProjectID,AttachName,Filepath,Created_user,Created_date,Audit_user,Audit_date) VALUES (@ProjectID,@AttachName,@Filepath,@Created_user,@Created_date,@Audit_user,@Audit_date);SELECT @@IDENTITY;";
        //                SqlParameter[] paramAdd = new SqlParameter[]
        //                {
        //                    new SqlParameter("@ProjectID",attachment.ProjectID),
        //                    new SqlParameter("@AttachName",attachment.AttachName),
        //                    new SqlParameter("@Filepath",attachment.Filepath),
        //                    new SqlParameter("@Created_user",attachment.Created_user),
        //                    new SqlParameter("@Created_date",attachment.Created_date),
        //                    new SqlParameter("@Audit_user",attachment.Audit_user),
        //                    new SqlParameter("@Audit_date",attachment.Audit_date)
        //                };
        //                //SQLHelper.ExecuteNoQuery(sqlAdd, paramAdd);                        
        //                var re = Context.Database.ExecuteSqlCommand(sqlAdd, paramAdd);
        //                if (re > 0)
        //                    _Logger.Info("PM_Attachmentд��ɹ���");
        //                else
        //                    _Logger.Error("PM_Attachmentд��ʧ�ܣ�", re.ToString());
        //            }
        //            return Json(new { success = true, msg = "��ӳɹ�" });
        //        }
        //        else
        //            return Json(new { success = false, msg = "���ʧ��" });
        //    }
        //    catch (Exception ex)
        //    {
        //        ex = ex.GetBaseException();
        //        _Logger.Error(ex.Message, "��������");
        //        return Json(new { success = false, msg = "��ӳ���:" + ex.Message });
        //    }
        //}

        /// <summary>
        /// Json��ȡģ����Ϣ
        /// </summary>
        /// <returns></returns>
        //[PMAuthorizeFilter]
        //public JsonResult GetModelInfo()
        //{
        //    //PM_Contact contact = new PM_Contact();
        //    CustomerVm vm = new CustomerVm();

        //    //contact.Contact_TelNo = Encryption.AESDecrypt(Request.Cookies["contactId"]);
        //    int account = Convert.ToInt32(Request.Query["grade"]);
        //    //string userType = Request.Cookies["userType"];
        //    string model = "";

        //    model = " select m.s_code,m.s_descript from PM_Mode m left join PM_System s on m.systemid = s.systemid where m.systemid= " + account;

        //    //vm.modes = SQLHelper.ExecuteSqlToList<PM_Mode>(model);
        //    //var modes = from s in Context.PM_System join m in Context.PM_Mode.Where(x => x.IsActive == "Y" && x.systemid == account) on s.systemid equals m.systemid into temp select m;
        //    var modes = from m in Context.PM_Mode.Where(x => x.IsActive == "Y" && x.systemid == account) join s in Context.PM_System on m.systemid equals s.systemid into temp select m;
        //    vm.modes = modes.ToList();
        //    return Json(vm.modes);
        //}

        /// <summary>
        /// Json��ȡϵͳ��Ϣ
        /// </summary>
        /// <returns></returns>
        //[TypeFilter(typeof(PMAuthorizeFilter))]
        //public JsonResult JsonSystemInfo()
        //{
        //    CustomerVm vm = new CustomerVm();
        //    string customerId = Request.Cookies["txtName"];

        //    //SQLHelper.SetConnection("PmDb");
        //    string model = "  select * from PM_Customer_System c  left join PM_System s on c.systemid = s.systemid where c.customerid = " + customerId;

        //    //vm.systems = SQLHelper.ExecuteSqlToList<pm_system>(model);
        //    return Json(vm.systems);
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
            //Request.Cookies["contactId"].Expires = time;
            //Request.Cookies["contactPwd"].Expires = time;
            //Request.Cookies["userType"].Expires = time;
            //Request.Cookies["contactUserId"].Expires = time;
            //Session["PMUSer"] = null;
            Response.Cookies.Delete("wechatOpenid");
            //Response.Clear();
            return Redirect(Url.Content("~/Home/CustomerLogin"));
        }

        //[TypeFilter(typeof(PMAuthorizeFilter))]
        //public ActionResult Questions(string id)
        //{
        //    List<Project> list = GetQuestions(0, 25, id);
        //    HttpCookie cid = new HttpCookie();
        //    cid.Value = Request.Cookies["cid"];
        //    //if (cid == null)
        //    //    cid = new HttpCookie("cid");
        //    cid.Expires = DateTime.Now.AddDays(7);
        //    cid.Value = string.IsNullOrWhiteSpace(id) ? "0" : id;
        //    Response.Cookies.Append("cid", cid.Value);
        //    ViewBag.CID = id;
        //    if (!string.IsNullOrEmpty(id) && id != "0")
        //    {
        //        //string sql = "SELECT CustomerName FROM PM_Customer WHERE CustomerID = @id";
        //        //DbContext db = new DbContext(ConfigurationManager.ConnectionStrings["pmDb"].ConnectionString);
        //        //ViewBag.CName = db.Database.SqlQuery<string>(sql, new SqlParameter("@id", id)).FirstOrDefault();

        //        var customerName = Context.PM_Customer.FirstOrDefault(x => x.Customerid == Convert.ToDecimal(id)).CustomerName;
        //        ViewBag.CName = customerName;
        //    }
        //    return View(list);
        //}
        //[TypeFilter(typeof(PMAuthorizeFilter))]
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
            string sql = @"SELECT ProjectNo,Ps.systemname AS System,ProjectDesc AS Describe,St.descript AS Status,Pro.Created_Date,Pro.Created_user,Resultion
,PMC.Customerid,St.IsFinish FROM PM_Project Pro
INNER JOIN PM_System Ps ON Pro.Systemtypeid = Ps.systemid
INNER JOIN PM_Status St ON Pro.Status = St.status
INNER JOIN PM_Customer PMC ON PMC.Customerid = Pro.Customerid";
            if (string.IsNullOrEmpty(id))
            {
                sql += " WHERE Pro.Created_user =@user ORDER BY Pro.Created_Date DESC";
                //return db.Database.SqlQuery<Project>(sql, new SqlParameter("@user", account)).Skip(index * size).Take(size).ToList();
                return CCAS.Utils.SqlHelper.SqlQuery<Project>(Context, sql, new SqlParameter("@user", Encryption.AESDecrypt(Request.Cookies["contactId"]))).Skip(index * size).Take(size).ToList();
            }
            else
            {
                sql += " WHERE PMC.Customerid = @id ORDER BY Pro.Created_Date DESC";
                //return db.Database.SqlQuery<Project>(sql, new SqlParameter("@id", id)).Skip(index * size).Take(size).ToList();
                return CCAS.Utils.SqlHelper.SqlQuery<Project>(Context, sql, new SqlParameter("@id", id)).Skip(index * size).Take(size).ToList();
            }
        }

        //public JsonResult CheckAttach(string projNo)
        //{
        //    if (string.IsNullOrWhiteSpace(projNo))
        //        return Json(new { success = false, data = "projNo����Ϊ��" });

        //    var proj = Context.PM_Project.FirstOrDefault(x => x.ProjectNo == projNo);
        //    if (proj == null)
        //        return Json(new { success = false, data = "��ȡ�����������" });

        //    var attach = Context.PM_Attachment.FirstOrDefault(x => x.ProjectID == proj.ProjectID);
        //    if (attach != null)
        //        return Json(new { success = true, data = attach.Filepath });
        //    else
        //        return Json(new { success = false, data = "������û����ظ���" });
        //}

        public ActionResult Error()
        {
            return View();
        }
    }
}
