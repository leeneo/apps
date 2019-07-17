using CCAS.VModels;
using Microsoft.Extensions.Options;

namespace CCAS.Utils
{
    public class WxOptions : BaseCommon, IOptions<WxSettings>
    {
        public WxOptions(IOptions<WxSettings> wxSettings) : base(wxSettings) { }

        public WxSettings Value => _WxSettings.Value;
    }
}