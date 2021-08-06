using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewGP.Models;
using NewGP.ViewModels;

namespace NewGP.Controllers
{
    public class LostpersonController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Lostperson
        //-----------------------------LIST------------------------------
        public ActionResult Listmiss()
        {
            var miss = db.Missperson;
            return View(miss.ToList());
        }
        //-----------------------------DETAILS--------------------------------------------//
        public ActionResult Details(int id)
        {

            var miss = db.Missperson.SingleOrDefault(x => x.ID == id);
            return View(miss);
        }
        //------------------------------ADD--------------------------------------------------------//
        [HttpGet] public ActionResult AddMiss(){
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddMiss(HttpPostedFileBase file, missperson m)
        {
        
            int userid = Convert.ToInt32(Session["UserID"]);
            int adminid = Convert.ToInt32(Session["adminId"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }

            if (Session["UserID"] != null)
            {
                m.UserID = userid;
                Session["adminId"] = null;
            }
           
            if (Session["adminId"] != null)
            {
                m.adminId = adminid;
                Session["UserID"] = null;
            }
           
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yyssmmff") + filename;
            string extention = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/images/"), _filename);
            m.Image = "~/images/" + _filename;
            m.Creaton = DateTime.Now;
            if (extention.ToLower() == ".jpeg" || extention.ToLower() == ".png" || extention.ToLower() == ".jpg")
            {
                if (file.ContentLength <= 1000000)
                {
                    db.Missperson.Add(m);

                    if (db.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "MissPerson Added";
                        ModelState.Clear();
                    }
                }
                else { ViewBag.msg = "File small"; }
            }
            else { ViewBag.msg = "Invalid this type"; }


            return RedirectToAction("Listmiss", "Lostperson");
        }
        //------------------------------EDIT---------------------------------------------------------------//
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var miss = db.Missperson.Find(id);
            int adminid = Convert.ToInt32(Session["adminId"]);

            int userid = Convert.ToInt32(Session["UserID"]);
         /*   if (userid == 0)
            {
                return RedirectToAction("Login", "Account");
            }*/
             if (userid == miss.UserID)
            {
                Session["imgpath"] = miss.Image;

                if (miss == null)
                {
                    return HttpNotFound();
                }
                return View(miss);
            }
            else if (adminid == miss.adminId)
            {

                Session["imgpath"] = miss.Image;

                if (miss == null)
                {
                    return HttpNotFound();
                }
                return View(miss);
            }
            return View();

           }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, missperson m)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;

                    string extension = Path.GetExtension(file.FileName);

                    string path = Path.Combine(Server.MapPath("~/images/"), _filename);

                    m.Image = "~/images/" + _filename;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (file.ContentLength <= 1000000)
                        {
                            db.Entry(m).State = EntityState.Modified;
                            string oldImgPath = Request.MapPath(Session["imgpath"].ToString());

                            if (db.SaveChanges() > 0)
                            {
                                file.SaveAs(path);
                                if (System.IO.File.Exists(oldImgPath))
                                {
                                    System.IO.File.Delete(oldImgPath);
                                }
                                TempData["msg"] = "Data Updated";
                                return RedirectToAction("Listmiss");
                            }
                        }
                        else
                        {
                            ViewBag.msg = "File Size must be Equal or less than 1mb";
                        }
                    }
                    else { ViewBag.msg = "Inavlid File Type"; }
                }
                else
                {
                    m.Image = Session["imgpath"].ToString();
                    db.Entry(m).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "Data Updated";
                        return RedirectToAction("Listmiss");
                    }

                }
            }
            return View();
        }
        ///-----------------------------DELETE---------------------------------------------------------------------///
        public ActionResult Delete(int? id)
        {
            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            var miss = db.Missperson.Find(id);
            int adminid = Convert.ToInt32(Session["adminId"]);
            int userid = Convert.ToInt32(Session["UserID"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            if (userid == miss.UserID)
            {
               if (userid == miss.UserID)
            {
                if (miss == null)
                {
                    return HttpNotFound();
                }
                string currentimage = Request.MapPath(miss.Image);
                db.Entry(miss).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    if (System.IO.File.Exists(currentimage))
                    {
                        System.IO.File.Delete(currentimage);
                    }
                    TempData["msg"] = "Deleted";
                    return RedirectToAction("Listmiss");
                }
            }
            }
            else if (adminid == miss.adminId) {

                if (miss == null)
                {
                    return HttpNotFound();
                }
                string currentimage = Request.MapPath(miss.Image);
                db.Entry(miss).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    if (System.IO.File.Exists(currentimage))
                    {
                        System.IO.File.Delete(currentimage);
                    }
                    TempData["msg"] = "Deleted";
                    return RedirectToAction("Listmiss");
                }
            }

            
            return View();
        }
        //-------------------------------SEARCH---------------------------------------------------------
        public ActionResult Search(string searching)
        {
            return View(db.Missperson.Where(x => x.Fname.Contains(searching) || x.Lname.Contains(searching) || x.city.Contains(searching) || searching == null).ToList());
        }
        //-------------------------------SEARCH IN DETAILS----------------------------------------------
        public ActionResult SearchInDetailes(string searchbyFN, string searchbyLN, string searchbycity, string searchbycountry, string searchbyplacefound)
        {
            return View(db.Missperson.Where
                (x => x.Fname.Contains(searchbyFN) && x.Lname.Contains(searchbyLN) && x.city.Contains(searchbyLN) && x.Country.Contains(searchbycountry) && x.placemiss.Contains(searchbyplacefound)).ToList());
        }
        
        //--------------------------------COMMENT------------------------------------------------------
        public ActionResult comment(string commentText)
        {
            int userId = Convert.ToInt32(Session["UserID"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            Misscomments c = new Misscomments();
            c.text = commentText;
            c.Creaton = DateTime.Now;
            c.UserID = userId;
            db.misscomments.Add(c);
            db.SaveChanges();
            return RedirectToAction("Details");
        }        
    }
}