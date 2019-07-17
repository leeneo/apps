using CCAS.Models;
using CCAS.VModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace CCAS.Controllers
{
    public class UnityController : Controller
    {
        private readonly IOptions<AppSettings> _settings;

        public UnityController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        //public ActionResult MobileBindMobileVerifyCode(string mobile)
        //{
        //}
    }
}
