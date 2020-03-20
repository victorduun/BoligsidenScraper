using System;
using System.Collections.Generic;
using System.Text;

namespace BoligsidenScraper.Scrapers.Searchsite
{
    class Municipalities
    {
        public static IEnumerable<string> MunicipalityCollection { get
            {
                List<string> Municipalities = new List<string>();
                foreach (var field in typeof(Municipalities).GetFields())
                {
                    Municipalities.Add(Convert.ToString(field.GetValue(null)));
                }
                return Municipalities;
            } 
        }

        public static string Albertslund = "albertslund";
        public static string Alleroed = "alleroed";
        public static string Assens = "assens";
        public static string Ballerup = "ballerup";




        public static string Koebenhavn = "koebenhavn";
    }
}
