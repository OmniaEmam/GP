using NewGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class ReturnController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ReturnList()
        {
            return View(db.Return.ToList());
        }
        //-----------------More---------------------------------------
        public ActionResult more(int id)
        {
            var r = db.Return.SingleOrDefault(x => x.ID == id);
            return View(r);
        }









    }
}