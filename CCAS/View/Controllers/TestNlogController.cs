using CCAS.Models;
using Microsoft.AspNetCore.Mvc;
using NLog;
using System;

namespace CCAS.Controllers
{
    public class TestNlogController : Controller
    {
        private readonly Db _context;
        private readonly ILogger _logger;

        public TestNlogController()
        {
            _logger = LogManager.GetLogger("test");                 //构造中注入使用
            _context = new Db();
        }

        public string Log()
        {
            //var logger = LogManager.GetLogger("test");            //直接实例化使用
            //logger.Error("LLLL");
            var ex = new Exception("222222");
            _logger.Error(ex,"TTTT中文测试");
            return _logger.Name;
        }
    }
}
