using CCAfterSales.Models;
using Microsoft.Extensions.Options;

namespace CCAfterSales.Utils
{
    public class WxOptions : BaseCommon, IOptions<WxSettings>
    {
        public WxOptions(IOptions<WxSettings> wxSettings) : base(wxSettings) { }

        public WxSettings Value => _WxSettings.Value;
    }
}