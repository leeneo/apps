﻿using CCAfterSales.Models;
using CCAS.Model;
using Microsoft.Extensions.Options;
using NLog;

namespace CCAfterSales.Utils
{
    public class BaseCommon
    {
        string logName = "CCAS/Common";

        protected static AppDbContext Context { get; set; }
        protected static ILogger _Logger { get; set; }
        protected static IOptions<AppSettings> _AppSettings { get; set; }
        protected static IOptions<WxSettings> _WxSettings { get; set; }

        protected BaseCommon()
        {
            _Logger = LogManager.GetLogger(logName);
        }
        protected BaseCommon(IOptions<AppSettings> appSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
        }
        protected BaseCommon(IOptions<WxSettings> wxSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _WxSettings = wxSettings;
        }
        protected BaseCommon(IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings)
        {
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
        }
        protected BaseCommon(IOptions<AppSettings> appSettings, IOptions<WxSettings> wxSettings, bool isUseDb)//内置Logger注入
        {
            //if (isUseDb)
            //    Context = new DbContext();
            //_HostingEnv = env;
            _Logger = LogManager.GetLogger(logName);
            _AppSettings = appSettings;
            _WxSettings = wxSettings;
        }
    }
}