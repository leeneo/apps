using CCAS.VModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CCAS.Controllers
{
    public class WxSettingsController: Controller
    {
        private readonly IOptions<WxSettings> _settings;

        public WxSettingsController(IOptions<WxSettings> settings)
        {
            _settings = settings;
        }
        public string Index()
        {
            var v = _settings.Value.OAuth2_URL;
            return v;
        }
    }
}
