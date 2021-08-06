using System.Web.Mvc;
using NewGP.ViewModels;

namespace NewGP.Controllers
{
    public class ContactUsController : Controller
    {
        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ContactUsVM obj)
        {
            string email = obj.Email;
            string fullname = obj.Fullname;
            string msg = obj.Message;
            string recvMail = "reunionadm.2@gmail.com";
            string message = $@"
                <h1 style='text-align:center; direction:ltr;'> New Email Arrived!</h1>
                <h3 style='direction:ltr;'>Fullname: <b>{fullname}</b></h3>
                <h3 style='direction:ltr;'>E-Mail: <b>{email}</b><h3>
                <p style='font-size:20px; direction:ltr;'>{msg}</p>
            ";
            Utils.sendMailingMsg(recvMail, "Admin", "Email from Contact Us Form!" ,message);
            ViewBag.msg = "Successfully sent email";
            ModelState.Clear();
            return View();
        }
    }
}
