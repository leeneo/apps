using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRChat.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Ind()
        {
            ViewBag.ClientName = "聊客-" + Guid.NewGuid().ToString("N");
            var onLineUserList = ChatHub.OnLineUsers.Select(u => new SelectListItem() { Text = u.Value, Value = u.Key }).ToList();
            onLineUserList.Insert(0, new SelectListItem() { Text = "-所有人-", Value = "TTTT" });
            ViewBag.OnLineUsers = onLineUserList;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Chat()
        {

            return View();
        }
    }
}