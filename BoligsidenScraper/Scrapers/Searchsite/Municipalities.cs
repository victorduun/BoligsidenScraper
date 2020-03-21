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
        public static string Billund = "billund";
        public static string Bornholm = "bornholm";
        public static string Broendby = "broendby";
        public static string Broenderslev = "broenderslev";

        public static string Dragoer = "dragoer";

        public static string Egedal = "egedal";
        public static string Esbjerg = "esbjerg";

        public static string Fanoe = "fanoe";
        public static string Favrskov = "favrskov";
        public static string Faxe = "faxe";
        public static string Fredensborg = "fredensborg";
        public static string Fredericia = "fredericia";
        public static string Frederiksberg = "frederiksberg";
        public static string Frederikshavn = "frederikshavn";
        public static string Frederikssund = "frederikssund";
        public static string Furesoe = "furesoe";
        public static string Faaborg_midtfyn = "faaborg-midtfyn";

        public static string Gentofte = "gentofte";
        public static string Gladsaxe = "gladsaxe";
        public static string Greve = "greve";
        public static string Gribskov = "gribskov";
        public static string Guldborgsund = "guldborgsund";

        public static string Haderslev = "haderslev";
        public static string Halsnaes = "halsnaes";
        public static string Hedensted = "hedensted";
        public static string Helsingoer = "helsingoer";
        public static string Herlev = "herlev";
        public static string Herning = "herning";
        public static string Hilleroed = "hilleroed";
        public static string Hjoerring = "hjoerring";
        public static string Holbaek = "holbaek";
        public static string Holstebro = "holstebro";
        public static string Horsens = "horsens";
        public static string Hvidovre = "hvidovre";
        public static string Hoeje_taastrup = "hoeje-taastrup";
        public static string Hoersholm = "hoersholm";

        public static string Ikast_brande = "ikast-brande";
        public static string Ishoej = "ishoej";

        public static string Jammerbugt = "jammerbugt";

        public static string Kalundborg = "kalundborg";
        public static string Kerteminde = "kerteminde";
        public static string Kolding = "kolding";
        public static string Koebenhavn = "koebenhavn";
        public static string Koege = "koege";

        public static string Langeland = "langeland";
        public static string Lejre = "lejre";
        public static string Lemvig = "lemvig";
        public static string Lolland = "lolland";
        public static string Lyngby_taarbaek = "lyngby-taarbaek";
        public static string Laesoe = "laesoe";

        public static string Mariagerfjord = "mariagerfjord";
        public static string Middelfart = "middelfart";
        public static string Morsoe = "morsoe";

        public static string Norddjurs = "norddjurs";
        public static string Nordfyns = "nordfyns";
        public static string Nyborg = "nyborg";
        public static string Naestved = "naestved";

        public static string Odder = "odder";
        public static string Odense = "odense";
        public static string Odsherred = "odsherred";

        public static string Randers = "randers";
        public static string Rebild = "rebild";
        public static string Ringkoebing_skjern = "ringkoebing-skjern";
        public static string Ringsted = "ringsted";
        public static string Roskilde = "roskilde";
        public static string Rudersdal = "rudersdal";
        public static string Roedovre = "roedovre";

        public static string Samsoe = "samsoe";
        public static string Silkeborg = "silkeborg";
        public static string Skanderborg = "skanderborg";
        public static string Skive = "skive";
        public static string Slagelse = "slagelse";
        public static string Solroed = "solroed";
        public static string Soroe = "soroe";
        public static string Stevns = "stevns";
        public static string Struer = "struer";
        public static string Svendborg = "svendborg";
        public static string Syddjurs = "syddjurs";
        public static string Soenderborg = "soenderborg";

        public static string Thisted = "thisted";
        public static string Toender = "toender";
        public static string Taarnby = "taarnby";

        public static string Vallensbaek = "vallensbaek";
        public static string Varde = "varde";
        public static string Vejen = "vejen";
        public static string Vejle = "vejle";
        public static string Vesthimmerland = "vesthimmerland";
        public static string Viborg = "viborg";
        public static string Vordingborg = "vordingborg";

        public static string Aeroe = "aeroe";

        public static string Aabenraa = "aabenraa";
        public static string Aalborg = "aalborg";
        public static string Aarhus = "aarhus";

    }
}
