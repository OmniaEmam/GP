using NewGP.Models;
using NewGP.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace NewGP.Controllers
{
    public class AccountController : Controller
    {
        // GET: User
        private ApplicationDbContext db = new ApplicationDbContext();
       
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterVM obj)
        { 
            bool UserExists = db.Susers.Any(x => x.Username == obj.Username);
            if (UserExists)
            {
                ViewBag.UsernameMessage = "This username already exists";
                return View();
            }
            bool Emailexsists = db.Susers.Any(y => y.Email == obj.Email);
            if (Emailexsists)
            {
                ViewBag.EmailMessage = "This Email already exists";
                return View();
            }
            string token = Utils.genToken(10);
            User u = new User();
            u.Username = obj.Username;
            u.Brithdate = obj.Brithdate;
            u.Email = obj.Email;
            u.city = obj.city;
            u.Password = obj.Password;
            u.ImageUrl = "";
            u.token = token;
            u.verified = false;
            u.Country = obj.Country;
            u.Ismale = obj.Ismale;
            u.Creaton = DateTime.Now;
            if(Utils.sendMail(u.Email, u.Username, u.token, u.Username))
            {
                db.Susers.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Register");
            }
        }


        [HttpGet]
        public ActionResult Login()
        { return View();}
        [HttpPost]
        public ActionResult Login(LoginVM obj)
        {
            bool exists = db.Susers.Any(x => x.Username == obj.Username && x.Password == obj.Password);
            bool Adminexists = db.admin.Any(x => x.Username == obj.Username && x.Password == obj.Password);
            if (exists)
            {
                var fetchedUser = db.Susers.Single(x => x.Username == obj.Username);
                Session["UserID"] = fetchedUser.Id;
                Session["ImageUrl"] = fetchedUser.ImageUrl;
                Session["role_sec"] = "user";
                return RedirectToAction("UserProfile", "User");
            }
            else if (Adminexists) {
                Session["adminId"] = db.admin.Single(x => x.Username == obj.Username).adminId;
                Session["role_sec"] = "admin";
                return RedirectToAction("Index", "Admin");
            }else{
                ViewBag.InvaildMessage = "Invaild credentials or you need to activate your account.";
                Session["role_sec"] = "user_normal";
                return View();
            }
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("UserId");
            Session.Remove("adminId");
            Session.Clear();
            Session["role_sec"] = "user_normal";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult Activate()
        {
            string token = Utils.GetUrlParameter(Request, "token");
            string uname = Utils.GetUrlParameter(Request, "uname");
            var fetchedUser = db.Susers.FirstOrDefault(x => x.Username == uname);
            if (token == "" || uname == "")
            {
                ViewBag.msg = "No token or username provieded!";
            }else if (fetchedUser == null || fetchedUser.token != token)
            {
                ViewBag.msg = "Wrong Username or token!";
            }else{
                fetchedUser.verified = true;
                fetchedUser.token = Utils.genToken(10);
                db.SaveChanges();
                ViewBag.msg = "Account Activated! You can now login to your account.";
            }
            return View();
        }
    } 
}