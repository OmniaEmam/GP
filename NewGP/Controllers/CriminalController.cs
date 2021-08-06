using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewGP.Models;

namespace NewGP.Controllers
{
    public class CriminalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Criminal
        public ActionResult Listkidnap()
        {
           
            return View(db.kidnaps.ToList());
        }
        public ActionResult Listvedio()
        {
            
            return View(db.vedios.ToList());
        }
        public ActionResult Detailsvedio(int id)
        {
            var crimesvedio = db.vedios.SingleOrDefault(x => x.id == id);
            return View(crimesvedio);
        }
        public ActionResult Details(int id)
        {
           
            var kid = db.kidnaps.SingleOrDefault(x => x.id == id);
            return View(kid);
        }
        [HttpGet] 
        public ActionResult Addkidnap() 
        {
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
        [HttpPost]
        public ActionResult Addkidnap(HttpPostedFileBase file, Kidnap k)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            k.UserID = userid;
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yyssmmff") + filename;
            string extention = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/images/"), _filename);
            k.image = "~/images/" + _filename;
            k.creaton = DateTime.Now;
            if (extention.ToLower() == ".jpeg" || extention.ToLower() == ".png" || extention.ToLower() == ".jpg")
            {
                if (file.ContentLength <= 1000000)
                {
                    db.kidnaps.Add(k);

                    if (db.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "criminal Added";
                        ModelState.Clear();
                    }
                }
                else { ViewBag.msg = "File small"; }
            }
            else { ViewBag.msg = "Invalid this type"; }


            return RedirectToAction("Listkidnap", "Criminal");
        }
        [HttpGet] public ActionResult addcrimeVedio() {
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult addcrimeVedio(HttpPostedFileBase vediofile, Crimesvidio v)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            v.UserID = userid;
            string filename = Path.GetFileName(vediofile.FileName);
           
           string path = Path.Combine(Server.MapPath("~/Vediofile/"),filename);
            v.Vfile = "~/Vediofile/" + filename;
            if (vediofile.ContentLength <= 0) return null;
            
                 db.vedios.Add(v);

                if (db.SaveChanges() > 0)
                {
                    vediofile.SaveAs(path);
                    ViewBag.msg = "criminal Added";
                    ModelState.Clear();
                } 
        return View("addcrimeVedio");  
        }
    }
}