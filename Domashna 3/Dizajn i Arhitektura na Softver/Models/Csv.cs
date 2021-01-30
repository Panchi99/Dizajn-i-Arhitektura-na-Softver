using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Dizajn_i_Arhitektura_na_Softver.Models
{
    public class Csv
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

        public void initialize()
        {
            longitude = new List<String>();
            latitude = new List<String>();
            ID = new List<String>();
            Name = new List<String>();
            openingHours = new List<String>();
            cashPayment = new List<String>();
            masterCardPayment = new List<String>();
            visaPayment = new List<String>();
            fuel95 = new List<String>();
            fuel98 = new List<String>();
            fuelDiesel = new List<String>();
            fuelLPG = new List<String>();
            AvgRating = new List<String>();
            CountRatings = new List<String>();
            selectLists = new List<SelectListItem>();
        }

        public void fillSelectList()
        {
            SelectListItem item1 = new SelectListItem() { Text = "1", Value = "1", };
            SelectListItem item2 = new SelectListItem() { Text = "2", Value = "2", };
            SelectListItem item3 = new SelectListItem() { Text = "3", Value = "3" };
            SelectListItem item4 = new SelectListItem() { Text = "4", Value = "4" };
            SelectListItem item5 = new SelectListItem() { Text = "5", Value = "5" };
            selectLists.Add(item1);
            selectLists.Add(item2);
            selectLists.Add(item3);
            selectLists.Add(item4);
            selectLists.Add(item5);
            list = selectLists;
        }
        public Csv() {

            initialize();
            fillSelectList();
        }
        public void csvFile()
    {
        string path = HttpContext.Current.Server.MapPath(@"../BenziskiPumpi.csv");
        using (var reader = new StreamReader(path, true))

        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                    addValuesToLists(values);
            }
        }
    }

        public void addValuesToLists(string[] values)
        {
            longitude.Add(values[1]);
            latitude.Add(values[2]);
            ID.Add(values[0]);
            Name.Add(values[3]);
            fuelDiesel.Add(values[4]);
            openingHours.Add(values[8]);
            cashPayment.Add(values[9]);
            masterCardPayment.Add(values[10]);
            visaPayment.Add(values[11]);
            fuel95.Add(values[14]);
            fuel98.Add(values[15]);
            fuelLPG.Add(values[16]);
        }
    public List<String> getLongitude() {
        return longitude;
    }

    public List<String> getLatitude()
    {
        return latitude;
    }

    public List<String> getName()
    {
        return Name;
    }

    public List<String> getID()
    {
        return ID;
    }

    public List<String> getFuelDiesel()
    {
        return fuelDiesel;
    }

    public List<String> getOpeningHours()
    {
        return openingHours;
    }

    public List<String> getCashPayment()
    {
        return cashPayment;
    }

    public List<String> getMasterCardPayment()
    {
        return masterCardPayment;
    }

    public List<String> getVisaPayment()
    {
        return visaPayment;
    }

    public List<String> getFuel95()
    {
        return fuel95;
    }

    public List<String> getFuel98()
    {
        return fuel98;
    }

    public List<String> getFuelLPG()
    {
        return fuelLPG;
    }
    public List<String> getAvgRating()
    {
        return AvgRating;
    }
    public List<String> getCountRatings()
    {
        return CountRatings;
    }


    }
}