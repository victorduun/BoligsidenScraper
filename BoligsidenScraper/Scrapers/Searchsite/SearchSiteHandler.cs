using System;
using System.Collections.Generic;
using System.Text;

namespace BoligsidenScraper.Scrapers.Searchsite
{
    public class SearchSiteHandler
    {

        private int CurrentPage { get; set; } = 0;

        public SearchSiteHandler()
        {

        }

        static public string GetElementOnPage(int id)
        {
            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(1)"
            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(2)"
            //"#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(30)"
            string selector = "#page-salesprice-result > div > div > div:nth-child(3) > div.row > div:nth-child(1)";
            throw new NotImplementedException();
        }
    }
}
