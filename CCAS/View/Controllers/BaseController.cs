using Microsoft.AspNetCore.Mvc;
using CCAS.Models;
using CCAS.VModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using NLog;
using CCAS.VModels.Menus;

namespace CCAS.Controllers
{
    public class BaseController : Controller
    {
        //private Db context;
        //private ILogger<BaseController> logger;
        //private IHostingEnvironment hostingEnv;
        //private IOptions<AppSettings> appSettings;
        //private IOptions<WxSettings> wxSettings;
        string logName = "CCAS";
        protected Db Context { get; set; }
        protected ILogger _Logger { get; set; }
        protected IHostingEnvironment _HostingEnv { get; set; }
        protected IOptions<AppSettings> _AppSettings { get; set; }
        protected IOptions<WxSettings> _WxSettings { get; set; }
        protected IOptions<WxMenus> _WxMenus { get; set; }

        protected BaseController()
        {
            _Logger = LogManager.GetLogger(logName);
        }

        protected BaseController(IOptions<AppSettings> appSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
        }
        protected BaseController(IOptions<WxSettings> wxSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _WxSettings = wxSettings;
        }
        protected BaseController(IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
        }
        protected BaseController(IHostingEnvironment env, IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings)//内置Logger注入
        {
            _HostingEnv = env;
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
        }
        protected BaseController(IHostingEnvironment env, IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings, bool isUseDb)//内置Logger注入
        {
            if (isUseDb)
                Context = new Db();
            _HostingEnv = env;
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
        }
        protected BaseController(IHostingEnvironment env, IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings, IOptions<WxMenus> wxMenus, bool isUseDb)//内置Logger注入
        {
            if (isUseDb)
                Context = new Db();
            _HostingEnv = env;
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
            _WxMenus = wxMenus;
        }
    }
}
