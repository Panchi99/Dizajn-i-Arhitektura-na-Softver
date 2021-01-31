using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GasStation_Microservice.Models
{
    public class GasStation
    {
        private List<String> longitude { get; set; }
        private List<String> latitude { get; set; }

        private List<String> ID { get; set; }

        private List<String> Name { get; set; }

        private List<String> openingHours { get; set; }

        private List<String> cashPayment { get; set; }

        private List<String> masterCardPayment { get; set; }

        private List<String> visaPayment { get; set; }

        private List<String> fuel95 { get; set; }

        private List<String> fuel98 { get; set; }

        private List<String> fuelDiesel { get; set; }

        private List<String> fuelLPG { get; set; }

        private List<String> AvgRating { get; set; }
        private List<String> CountRatings { get; set; }
        public int IDSelected { get; set; }
        public List<SelectListItem> selectLists { get; set; }
        public IEnumerable<SelectListItem> list { get; set; }
    }
}
