using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Dizajn_i_Arhitektura_na_Softver.Models
{
    public class Csv
    {
        private List<String> longitude  { get; set;}
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



        public Csv() { 
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
        }
        public void csvFile()
        {
            using (var reader = new StreamReader("C:/Users/user/Documents/GitHub/Dizajn-i-Arhitektura-na-Softver/Domashna 3/Dizajn i Arhitektura na Softver/BenziskiPumpi.csv"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

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
            }
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

    }
}