using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CcMis.Web.Controllers
{
    /// <summary>
    /// 客户
    /// </summary>
    [Authorize]
    public class GuestController : Controller
    {

        public string GetCustom()
        {
            return "";
        }

        /// <summary>
        /// 当前在住
        /// </summary>
        /// <returns></returns>
        public string NowLiving()
        {
            var data= new DGuest().Living();
            return data;
        }

        /// <summary>
        /// 今天预定
        /// </summary>
        /// <returns></returns>
        public string TodayReserve()
        {
            var data = new DGuest().Reserve();
            return data;
        }
        /// <summary>
        /// 今天离店
        /// </summary>
        /// <returns></returns>
        public string TodayLeave()
        {
            var data = new DGuest().Reserve();
            return data;
        }
    }
}
