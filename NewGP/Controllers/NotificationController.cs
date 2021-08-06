using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class NotificationController : Controller
    {
        //private readonly IConfiguration configuration;

        //public HomeController(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        //public IActionResult Index()
        //{
        //    ViewBag.applicationServerKey = configuration["VAPID:publicKey"];
        //    return View();
        //}
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }
    }
}