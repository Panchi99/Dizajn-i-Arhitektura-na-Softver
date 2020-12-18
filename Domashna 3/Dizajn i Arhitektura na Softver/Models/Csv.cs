using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;

namespace Dizajn_i_Arhitektura_na_Softver.Models
{
    public class Csv
    {
        private List<String> longitude  { get; set;}
        private List<String> latitude { get; set; }

        private int i;

        private int j;

        public Csv() { 
            longitude = new List<String>();
            latitude = new List<String>();
            i = 0;
            j = 0;
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

        public void setI()
        {
            i++;
        }

        public void setJ()
        {
            j++;
        }

        public int getI()
        {
            return i;
        }

        public int getJ()
        {
            return j;
        }
    }
}