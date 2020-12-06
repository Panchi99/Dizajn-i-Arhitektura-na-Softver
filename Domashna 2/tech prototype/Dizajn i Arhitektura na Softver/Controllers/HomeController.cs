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
namespace Dizajn_i_Arhitektura_na_Softver.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Map() {
            ViewBag.Mesage = "Your map page.";
            return View();
        }
        public ActionResult GasPrices()
        {
            ViewBag.Message = "gas prices.";
            return View();
        }
        
    }
}