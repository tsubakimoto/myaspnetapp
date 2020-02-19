using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace MyAspNetApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly MailSettingsSectionGroup mailSettings;

        static HomeController()
        {
            var config = WebConfigurationManager.OpenWebConfiguration("~/web.config");
            mailSettings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
        }

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

        public ActionResult Mail()
        {
            try
            {
                var mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress("y-matsumura@alterbooth.net", "yuta matsumura"));

                // From
                mailMsg.From = new MailAddress("from@example.com", "From Name");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                var text = "text body";
                var html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                var smtpClient = new SmtpClient(mailSettings.Smtp.Network.Host, mailSettings.Smtp.Network.Port);
                smtpClient.Credentials = new NetworkCredential(mailSettings.Smtp.Network.UserName, mailSettings.Smtp.Network.Password);

                smtpClient.Send(mailMsg);
                return Content("メールを送信しました");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
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

        public ActionResult Conn()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "127.0.0.1",
                IntegratedSecurity = false,
                UserID = "SA",
                Password = "P@ssw0rd!P@ssw0rd!"
            };
            return Content(builder.ToString());
        }

        public ActionResult Dir()
        {
            return Content(Directory.GetCurrentDirectory());
        }
    }
}