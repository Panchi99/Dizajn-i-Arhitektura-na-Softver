using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dizajn_i_Arhitektura_na_Softver.Models;

namespace Dizajn_i_Arhitektura_na_Softver.Controllers
{
    public class CsvController : Controller
    {
        // GET: Csv
        public ActionResult Index()
        {
            Csv csv = new Csv();
            csv.csvFile();
            return View(csv);
        }
    }
}