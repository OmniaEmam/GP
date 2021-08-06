using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;

namespace NewGP.Controllers
{
    public class SimilarityController : Controller
    {
        // GET: Similarity
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file1, HttpPostedFileBase file2)
        {
            try
            {
                if (file1.ContentLength > 0 && file2.ContentLength > 0)
                {
                    string _FileName1 = Path.GetFileName(file1.FileName);
                    string _path1 = Path.Combine("C:\\Users\\user\\Desktop\\Negotiation -20210701T204006Z-001\\Negotiation\\pythonProject\\pythonProject", "1.jpg");
                    file1.SaveAs(_path1);

                    string _FileName2 = Path.GetFileName(file2.FileName);
                    string _path2 = Path.Combine("C:\\Users\\user\\Desktop\\Negotiation -20210701T204006Z-001\\Negotiation\\pythonProject\\pythonProject", "2.jpg");
                    file2.SaveAs(_path2);

                }
                ViewBag.Message = "File Uploaded Successfully!!";
                Thread.Sleep(500);
                string text = System.IO.File.ReadAllText(@"C:\Users\user\Desktop\Negotiation -20210701T204006Z-001\Negotiation\pythonProject\pythonProject/u.txt");
                ViewBag.u = text;
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
        }
}