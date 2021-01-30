using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dizajn_i_Arhitektura_na_Softver.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;

namespace Dizajn_i_Arhitektura_na_Softver.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map()
        {
            Csv csv = new Csv();
            csv.csvFile();
            return View(csv);
        }
        [HttpPost]
        public ActionResult Map(Csv model)
        {
            return RedirectToAction("Map","Home"); 
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public MailMessage createMessage(SendMail model)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("petrolheadsbussiness@gmail.com"));
            message.From = new MailAddress(model.FromEmail);
            message.Subject = model.Subject;
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            return message;
        }

        public async Task<ActionResult> sendFromMicrosoftAsync(SendMail model, MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = false;
                var credential = new NetworkCredential
                {
                    UserName = model.FromEmail,
                    Password = model.Password
                };

                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");
            }
        }

        public async Task<ActionResult> sendFromGmailAsync(SendMail model, MailMessage message)
        {
            using (var smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = false;
                var credential = new NetworkCredential
                {
                    UserName = model.FromEmail,
                    Password = model.Password 
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Sent");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(SendMail model)
        {
            if (ModelState.IsValid)
            {
                var message = createMessage(model);

                if (model.FromEmail.Contains("@hotmail") || model.FromEmail.Contains("@outlook") || model.FromEmail.Contains("@msn")
                    || model.FromEmail.Contains("@live") || model.FromEmail.Contains("@msn"))

                    await sendFromMicrosoftAsync(model, message);
                
                else if (model.FromEmail.Contains("@gmail"))
                {
                    await sendFromGmailAsync(model, message);
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

       

       public async System.Threading.Tasks.Task<ActionResult> GasPrices()
        {

            var url = "https://www.erc.org.mk/";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divCeni = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("id", "")
                .Equals("CeniLista")).ToList();

            var lista = divCeni[0].Descendants("td")
                .ToList();

            Console.WriteLine(lista.ToString());
            ViewBag.Message = lista;
            return View();
        }
    }
}