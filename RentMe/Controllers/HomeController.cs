using RentMe.Models;
using RentMe.Models.Enums;
using RentMe.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RentMe.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {

            return View();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("kristijan@ncs.mk"));  // replace with valid value 
                message.From = new MailAddress("kristijan@ncs.mk");  // replace with valid value
                message.Subject = "Your email subject";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "kr.arsovski@gmail.com",  // replace with valid value
                        Password = "kikserce1@#"  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp-mail.outlook.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Rent(string searchBy, string search)
        {
           
            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Rent).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }
        public ActionResult Sale()
        {

            var Accommodations = db.Accommodations.Where(t => t.RentSale == RentSale.Sale).ToList();
            ViewBag.Message = "Your contact page.";
            return View(Accommodations);
        }
    }
}