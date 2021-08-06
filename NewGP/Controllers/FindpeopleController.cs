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
    public class FindpeopleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Findpeople
        //----------------LIST----------------------
        public ActionResult Listfound()
        { return View(db.Find.ToList()); }
        //-----------------DETAILS---------------------//
        public ActionResult Details(int id)
        {
            var find = db.Find.SingleOrDefault(x => x.id == id);
            return View(find);
        }
        //------------------ADD--------------------------------
        [HttpGet] 
        public ActionResult Addfoind(){
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Addfoind(HttpPostedFileBase file, findpeople f)
        {
            int userid = Convert.ToInt32(Session["UserID"]);
            int adminid = Convert.ToInt32(Session["adminId"]);
            if (Session["role_sec"].ToString() == "user_normal")
            {
                return RedirectToAction("Login", "Account");
            }

            if (Session["UserID"] != null)
            {
                f.UserID = userid;
                Session["adminId"] = null;
            }

            if (Session["adminId"] != null)
            {
                f.adminId = adminid;
                Session["UserID"] = null;
            }
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yyssmmff") + filename;
            string extention = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/images/"), _filename);
            f.Image = "~/images/" + _filename;
            f.Creaton = DateTime.Now;
            if (extention.ToLower() == ".jpeg" || extention.ToLower() == ".png" || extention.ToLower() == ".jpg")
            {
                if (file.ContentLength <= 1000000)
                {
                    db.Find.Add(f);

                    if (db.SaveChanges() > 0)
                    {
                        file.SaveAs(path);
                        ViewBag.msg = "FoundPerson Added";
                        ModelState.Clear();
                    }
                }
                else { ViewBag.msg = "File small"; }
            }
            else { ViewBag.msg = "Invalid this type"; }


            return RedirectToAction("Listfound", "Findpeople");
        }
        //-------------------EDIT---------------------------------------------------------------//
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var found = db.Find.Find(id);
            int adminid = Convert.ToInt32(Session["adminId"]);

            int userid = Convert.ToInt32(Session["UserID"]);
            /*  if (userid == 0)
              {
                  return RedirectToAction("Login", "Account");
              } */
            if (userid == found.UserID)
            {
                Session["imgpath"] = found.Image;

                if (found == null)
                {
                    return HttpNotFound();
                }
                return View(found);
            }
            else if (adminid == found.adminId) {

                Session["imgpath"] = found.Image;

                if (found == null)
                {
                    return HttpNotFound();
                }
                return View(found);
            }
            return View();

        }
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file, findpeople f)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string _filename = DateTime.Now.ToString("yymmssfff") + filename;

                    string extension = Path.GetExtension(file.FileName);

                    string path = Path.Combine(Server.MapPath("~/images/"), _filename);

                    f.Image = "~/images/" + _filename;

                    if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
                    {
                        if (file.ContentLength <= 1000000)
                        {
                            db.Entry(f).State = EntityState.Modified;
                            string oldImgPath = Request.MapPath(Session["imgpath"].ToString());

                            if (db.SaveChanges() > 0)
                            {
                                file.SaveAs(path);
                                if (System.IO.File.Exists(oldImgPath))
                                {
                                    System.IO.File.Delete(oldImgPath);
                                }
                                TempData["msg"] = "Data Updated";
                                return RedirectToAction("Listfound");
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
                    f.Image = Session["imgpath"].ToString();
                    db.Entry(f).State = EntityState.Modified;

                    if (db.SaveChanges() > 0)
                    {
                        TempData["msg"] = "Data Updated";
                        return RedirectToAction("Listfound");
                    }

                }
            }
            return View();
        }
        //---------------------DELETE-----------------------------------------------------//
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int adminid = Convert.ToInt32(Session["adminId"]);
            var found = db.Find.Find(id);
            int userid = Convert.ToInt32(Session["UserID"]);
            /*  if (userid == 0)
              {
                  return RedirectToAction("Login", "Account");
              }*/
            if (userid == found.UserID)
            {
                if (found == null)
                {
                    return HttpNotFound();
                }
                string currentimage = Request.MapPath(found.Image);
                db.Entry(found).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    if (System.IO.File.Exists(currentimage))
                    {
                        System.IO.File.Delete(currentimage);
                    }
                    TempData["msg"] = "Deleted";
                    return RedirectToAction("Listfound");
                }
            }
            else if (adminid == found.adminId) {
                if (found == null)
                {
                    return HttpNotFound();
                }
                string currentimage = Request.MapPath(found.Image);
                db.Entry(found).State = EntityState.Deleted;
                if (db.SaveChanges() > 0)
                {
                    if (System.IO.File.Exists(currentimage))
                    {
                        System.IO.File.Delete(currentimage);
                    }
                    TempData["msg"] = "Deleted";
                    return RedirectToAction("Listfound");
                }


            }
                return HttpNotFound();
            }
        //----------------------SEARCH--------------------------------------------------------//
        public ActionResult Search(string searching)
        {
            return View(db.Missperson.Where(x => x.Fname.Contains(searching) || x.Lname.Contains(searching) || x.city.Contains(searching) || searching == null).ToList());
        }
        //-----------------------SEARCH IN DETAILS------------------------------------------------------
        public ActionResult SearchInDetailes(string searchbyFN, string searchbyLN, string searchbycity, string searchbycountry, string searchbyplacefound)
        {
            return View(db.Find.Where
                (x => x.Firstname.Contains(searchbyFN) && x.Lastname.Contains(searchbyLN) && x.city.Contains(searchbyLN) && x.Country.Contains(searchbycountry) && x.placefound.Contains(searchbyplacefound)).ToList());
        }
    }
}