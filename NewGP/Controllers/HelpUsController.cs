using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class HelpUsController : Controller
    {
       
        // GET: HelpUs
        public ActionResult Index()
        {
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
                
            }
            return View();
        }
    }
}