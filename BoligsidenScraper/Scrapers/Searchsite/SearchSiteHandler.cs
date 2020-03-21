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

        private int CurrentPage { get; set; } = 1;

        public SearchSiteHandler(string municipality)
            :base()
        {
            Municipality = municipality;
        }

        private dynamic ExtractPropertySalesFromJson(string searchResult)
        { 
            //Deserialize into dynamic object
            dynamic searchResultDeserialized = JObject.Parse(searchResult);

            //Only include propetysales
            dynamic propertySales = searchResultDeserialized.searchResult.result.propertySales;

            return propertySales;
        }

        private async Task<List<PropertySale>> GetElementsOnPage()
        {
            var document = await ScrapeWebsite(SearchUrl);


            //Find the <scrip> section with sales results
            var salesScript = document.Scripts.Where(x =>
            x.InnerHtml.Contains("__bs_salespricelist_result__ "));

            //Replace the strings which break json formatting with null strings
            string searchResult = salesScript.Single().InnerHtml.Replace("\n    __bs_salespricelist_result__ = ", "").Replace(";\n    bs.page.initSalesPriceResult({});\n  ", "");

            List<PropertySale> dataModelSales = new List<PropertySale>();
            dynamic dynamicSales = ExtractPropertySalesFromJson(searchResult);
            foreach(var sale in dynamicSales)
                dataModelSales.Add(new PropertySale(sale));

            return dataModelSales;
        }

        public async Task<List<PropertySale>> GetAllPropertySales()
        {
            List<PropertySale> AllSales = new List<PropertySale>();
            List<PropertySale> salesOnPage;
            do
            {
                salesOnPage = await GetElementsOnPage();
                foreach (var sale in salesOnPage)
                    AllSales.Add(sale);
                CurrentPage++;

            } while (salesOnPage.Count == 30); //30 results per page, if there is less then it must be the last page

            return AllSales;
        }

    }
}
