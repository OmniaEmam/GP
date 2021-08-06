using NewGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class ChatController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Chat
        public ActionResult Index()
        {
            var userid = Convert.ToInt32(Session["UserID"]);
            if (userid == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Susers.Find(userid));
        }
    }
}