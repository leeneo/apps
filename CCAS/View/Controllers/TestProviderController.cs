using CCAfterSales.Models;
using CCAS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using NLog;

namespace CCAfterSales.Controllers
{
    public class TestProviderController : Controller
    {
        private readonly Db _context;
        private readonly ILogger _logger;
        public TestProviderController(LoggerProvider logger)
        {
            _logger = logger.CreateLogger("Information");
            _context = new Db();
        }

        public string Log()
        {
            _logger.LogInformation("LogInformation");
            _logger.LogError("TTTT");
            return "";
        }
    }
}
