using System.Linq;
using System.Web.Mvc;
using NewGP.Models;
namespace NewGP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            if( Session["role_sec"] == null )Session["role_sec"] = "user_normal";
            return View();
        }
        public ActionResult Search(string searching)
        {
            return View(db.Missperson.Where(x => x.Fname.Contains(searching) || x.Lname.Contains(searching) || x.city.Contains(searching) || searching == null).ToList());
        }
    }
}