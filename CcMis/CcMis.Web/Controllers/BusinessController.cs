using API;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CcMis.Web.Controllers
{
    /// <summary>
    /// 销售
    /// </summary>
    [Authorization]
    public class BusinessController : Controller
    {
        /// <summary>
        /// 营业日报
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string DailyReport(DateTime date)
        {
            var data = new DBusiness().DailyReport(date);
            return data;
        }

    }
}
