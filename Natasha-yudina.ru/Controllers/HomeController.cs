using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Natasha_yudina.ru.Models;

namespace Natasha_yudina.ru.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(bool? nopromo)
        {
            if (nopromo != null && nopromo.Value)
            {
                ViewBag.NoPromo = true;
            }
            else
            {
                ViewBag.NoPromo = false;
            }

            return View();
        }

        public ActionResult Gallery(string project, string id)
        {
            return View();
        }

        public ActionResult Biography()
        {
            return View();
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactForm(ContactModel model)
        {
            var from = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["serverEmail"], "Natasha-yudina.ru");
            var to = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["ownerEmail"]);

            var mm = new MailMessage(from, to)
            {
                Subject = model.Subject,
                Body = string.Format("ФИО: {0}<br/>" +
                                    "<b>Email:</b> {1}<br/><br/>{2}", 
                                    model.Name,
                                    model.Email,
                                    model.Message
                                    ),
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = true
            };

            var credentials = new NetworkCredential(System.Configuration.ConfigurationManager.AppSettings["serverEmail"], 
                System.Configuration.ConfigurationManager.AppSettings["serverEmailPass"]);
            var sc = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["serverEmailHost"],
                Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["serverEmailPort"]))
            {
                EnableSsl = true,
                Credentials = credentials
            };

            sc.Send(mm);

            return View("ContactFormFinish");
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}
