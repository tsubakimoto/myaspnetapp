using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace MyAspNetApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Users");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail()
        {
            // var smtp = new SmtpClient("127.0.0.1", 80);

            var smtp = new SmtpClient();
            smtp.Host = "127.0.0.1";
            smtp.Port = 80;

            // var smtp = new SmtpClient
            // {
            //     Host = "127.0.0.1",
            //     Port = 80
            // };

            smtp.Send("from@example.com", "to@example.com", "subj", "body");
            return Content(nameof(SendMail));
        }

        public ActionResult Now()
        {
            var nowString = HttpContext.Session["now"]?.ToString();
            if (string.IsNullOrWhiteSpace(nowString))
            {
                nowString = DateTime.Now.ToString();
                HttpContext.Session["now"] = nowString;
            }
            return Content(nowString);
        }
    }
}