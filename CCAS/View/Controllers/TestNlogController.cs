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
            _logger = LogManager.GetLogger("test");                 //������ע��ʹ��
            _context = new Db();
        }

        public string Log()
        {
            //var logger = LogManager.GetLogger("test");            //ֱ��ʵ����ʹ��
            //logger.Error("LLLL");
            var ex = new Exception("222222");
            _logger.Error(ex,"TTTT���Ĳ���");
            return _logger.Name;
        }
    }
}
