using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CcMis.Models;

namespace CcMis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //List<wxIndexMenu> res = ApiClient.Invoke<List<wxIndexMenu>>("DMenu", "GetMenus", null, false);
            //wxParameters introduction = ApiClient.Get<List<wxParameters>>("/wxparameters/getlist").FirstOrDefault(x => x.Name == "introduction");
            //if (introduction != null)
            //    ViewBag.introduction = introduction.Value;
            //var cookie = new CookieOperate();
            //ViewBag.MemberInfo = "WeChatOpenId=" + cookie.WeChatOpenId;
            //return View(res.Where(x => x.IsActive == "Y").ToList());
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
