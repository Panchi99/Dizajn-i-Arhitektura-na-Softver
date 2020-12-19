using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dizajn_i_Arhitektura_na_Softver.Models;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Dizajn_i_Arhitektura_na_Softver.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult mapata()
        {
            Csv csv = new Csv();
            csv.csvFile();
            return View(csv);
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(SendMail model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("petrolheadsbussiness@gmail.com"));  // replace with valid value 
                message.From = new MailAddress(model.FromEmail);  // replace with valid value
                message.Subject = model.Subject;

                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                if (model.FromEmail.Contains("@hotmail") || model.FromEmail.Contains("@outlook") || model.FromEmail.Contains("@msn")
                    || model.FromEmail.Contains("@live") || model.FromEmail.Contains("@msn"))
                {

                    using (var smtp = new SmtpClient())
                    {
                        smtp.UseDefaultCredentials = false;
                        var credential = new NetworkCredential
                        {
                            UserName = model.FromEmail,  // replace with valid value
                            Password = model.Password  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp-mail.outlook.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");
                    }
                }
                else if (model.FromEmail.Contains("@gmail"))
                {
                    using (var smtp = new SmtpClient())
                    {
                        smtp.UseDefaultCredentials = false;
                        var credential = new NetworkCredential
                        {
                            UserName = model.FromEmail,  // replace with valid value
                            Password = model.Password  // replace with valid value
                        };
                        smtp.Credentials = credential;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(message);
                        return RedirectToAction("Sent");
                    }
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }






        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View(new SendMail());
        }
        
        public ActionResult GasPrices()
        {
            ViewBag.Message = "gas prices.";
            return View();
        }
        
    }
}