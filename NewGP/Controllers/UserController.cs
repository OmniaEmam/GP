using NewGP.Models;
using NewGP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: User
        public ActionResult UserProfile()
        {
            var userid = Convert.ToInt32(Session["UserID"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Susers.Find(userid));
        }
        [HttpPost]
        public ActionResult UpdatePicture(PictcurVM obj)
        {
            var userid = Convert.ToInt32(Session["UserID"]);
            var File = obj.Picture;
            User u = db.Susers.Find(userid);
            if (File != null)
            {
                var extension = Path.GetExtension(File.FileName);
                string id_and_extension = userid + extension;
                string imagurl = "~/ProfileImages/" + id_and_extension;
                u.ImageUrl = imagurl;
                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                var path = Server.MapPath("~/ProfileImages/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if ((System.IO.File.Exists(path + id_and_extension)))
                { System.IO.File.Delete(path + id_and_extension); }
                File.SaveAs((path + id_and_extension));
            }
            return RedirectToAction("Userprofile");
        }

        //-----------------------------------------------------------
        [HttpGet]
        public ActionResult HelpUs()
        {

            int userid = Convert.ToInt32(Session["UserID"]);
            User u = db.Susers.SingleOrDefault(x => x.Id == userid);
            if (userid == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();

        }
        //    [HttpPost]

        //    public ActionResult HelpUs(VolanteerVM obj)
        //    {
        //        int userid = Convert.ToInt32(Session["UserID"]);
        //        Volanteer v = new Volanteer
        //        {
        //            PhoneNum = obj.PhoneNum,
        //            WorkPlace = obj.WorkPlace,
        //            UserID = userid,

        //        };
        //        db.volanteer.Add(v);
        //        db.SaveChanges();
        //        return RedirectToAction("UserProfile");



        //    }


        //}
    }
}