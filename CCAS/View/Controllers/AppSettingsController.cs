using CCAS.Models;
using CCAS.VModels;
using Microsoft.Extensions.Options;
using NLog;

namespace CCAS.Controllers
{
    public class AppSettingsController : BaseController
    {
        public AppSettingsController(IOptions<AppSettings> settings) : base(settings) { }

        public string Index()
        {
            var v = _AppSettings.Value.ClassName;
            return v;
        }
    }
}
