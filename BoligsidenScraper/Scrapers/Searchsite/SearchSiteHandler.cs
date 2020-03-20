using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BoligsidenScraper.Scrapers.Searchsite
{
    public class SearchSiteHandler : WebsiteScraper
    {
        private string SearchUrl { get
            {
                string url = "https://www.boligsiden.dk/salgspris/solgt/villa/" + CurrentPage + "?kommune=" + Municipality;


                return url;
            } 
        }

        private string Municipality { get; }

        private int CurrentPage { get; set; } = 3;

        public SearchSiteHandler(string municipality)
            :base()
        {
            Municipality = municipality;
        }

        public async Task<string> GetElementsOnPage()
        {
            var document = await ScrapeWebsite(SearchUrl);

            for (int i = 1; i<=30; i++)
            {
               
            }


            var salesScript = document.Scripts.Where(x =>
            x.InnerHtml.Contains("__bs_salespricelist_result__ "));
            string searchResult = salesScript.Single().InnerHtml.Replace("\n    __bs_salespricelist_result__ = ", "").Replace(";\n    bs.page.initSalesPriceResult({});\n  ","");
            dynamic searchResultDeserialized = JObject.Parse(searchResult);
            dynamic test = searchResultDeserialized.searchResult.result.propertySales;

            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(1)"
            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(2)"
            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(30)"
            string selector = "#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(1)";
            throw new NotImplementedException();
        }


    }
}
