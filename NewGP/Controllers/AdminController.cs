using NewGP.Models;
using NewGP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult regist()
        {

            return View();
        }
        [HttpPost]
        public ActionResult regist(Adminregist b)
        {
            bool adminExists = db.admin.Any(x => x.Username == b.Username);
            if (adminExists)
            {
                ViewBag.UsernameMessage = "This username already exists";
                return View();
            }
            bool Emailexsists = db.admin.Any(y => y.Email == b.Email);
            if (Emailexsists)
            {
                ViewBag.EmailMessage = "This Email already exists";
                return View();
            }
            Admin a = new Admin();
            a.Email = b.Email;
            a.Username = b.Username;
            a.phone = b.phone;
            a.Password = b.Password;
            a.Role = 1;
            a.adress = b.adress;
            db.admin.Add(a);
            db.SaveChanges();
            return RedirectToAction("Login","Account");
        }
        public ActionResult Mailing()
        {
            if (Session["role_sec"].ToString() == "admin")
            {
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Mailing(AdminSendVM obj)
        {
            if (Session["role_sec"].ToString() == "admin"){ 
                string recvMail = obj.Email;
                string subject = obj.Subject;
                string msg = obj.Message;
                string adminMail = "reunionadm.2@gmail.com";
                string message = $@"
                        <h1 style='text-align:center; direction:ltr;'> Email from Reunion!</h1>
                        <h3 style='direction:ltr;'>E-Mail From Admin: <b>{adminMail}</b><h3>
                        <p style='font-size:20px; direction:ltr;'>{msg}</p>
                    ";
                Utils.sendAdminMail(recvMail, "Admin", subject, message);
                ViewBag.msg = "Successfully sent email";
                ModelState.Clear();
                return View();
            }
            else
            {
                return HttpNotFound();
            }
        }
        //---------loggedin---------------------------------------//
        public ActionResult LoggedIn()
        {
            // if (Session["UserId"] != null)
            // {
            return View();
            // }
            /*else
            {
                return RedirectToAction("Login");
            }*/
        }
        //--------------update admin profile------------------------------------------//
        public ActionResult UpdateAdminProfile(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Admin admin = db.admin.Find(id);
            if (admin == null)
                return HttpNotFound();
            return View(admin);
        }
        // POST: AdminUpdate
        [HttpPost]
        public ActionResult UpdateAdminProfile(Admin admin)
        {
            try
            {
                // TODO: Add update logic here

                if (ModelState.IsValid)
                {
                    db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("LoggedIn");
                }
                return View(admin);
            }
            catch
            {
                return View();
            }
        }
        //---------------update user profile---------------------------------------//
        /* public ActionResult UpdateUserProfile(int? id)
         {
             if (id == null)
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             User user = db.Susers.Find(id);
             if (user == null)
                 return HttpNotFound();
             return View(user);
         }

         [HttpPost]
         public ActionResult UpdateUserProfile(User user)
         {
             if (ModelState.IsValid)
             {
                 db.Entry(user).State = EntityState.Modified;
                 db.SaveChanges();
                 return RedirectToAction("ListUsers");
             }
             return View(user);
         }*/
        //----------ListUsers---------------------------------------------//
        public ActionResult ListUsers()
        { return View(db.Susers.ToList()); }
        //----------List Admin---------------------------------------------//
        public ActionResult Listadmin()
        { return View(db.admin.ToList()); }
        //-------------Search user------------------------------------//
        public ActionResult SearchUser(string search)
        {
            return View(db.Susers.Where(x => x.Username.Contains(search) || search == null).ToList());

        }
        //---------------Detailies user---------------------//
        public ActionResult Details(int id)
        {
            var user = db.Susers.SingleOrDefault(x => x.Id == id);
            return View(user);
        }
        //---------------Detailies admin---------------------//
        public ActionResult Detailsadmin(int id)
        {
            var admin = db.admin.SingleOrDefault(x => x.adminId == id);
            return View(admin);
        }
        //---------------Delete user--------------------------------- //
        public ActionResult DeleteUser(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            User user = db.Susers.Find(id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            User user = db.Susers.Find(id);
            db.Susers.Remove(user);
            db.SaveChanges();
            return RedirectToAction("ListUsers");

        }
        //---------------Delete admin--------------------------------- //
        public ActionResult Deleteadmin(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            Admin admin = db.admin.Find(id);
            if (admin == null)
                return HttpNotFound();
            return View(admin);
        }
        [HttpPost]
        public ActionResult Deleteadmin(int id)
        {
            Admin admin = db.admin.Find(id);
            db.admin.Remove(admin);
            db.SaveChanges();
            return RedirectToAction("Listadmin");

        }
    }
}