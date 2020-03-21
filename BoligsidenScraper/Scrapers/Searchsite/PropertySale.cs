using System;
using System.Collections.Generic;
using System.Text;

namespace BoligsidenScraper.Scrapers.Searchsite
{
    public class PropertySale
    {
        private static string Domain = "boligsiden.dk";
        public PropertySale(dynamic propertySale)
        {
            ResidentialArea = propertySale.residentialArea;
            Postal = propertySale.postal;
            City = propertySale.city;
            Address = propertySale.address;
            PropertyType = propertySale.itemTypeName;
            BbrLink = Convert.ToString(propertySale.bbrLink);
            BbrLink = BbrLink.Replace("~", Domain);
            SoldLink = Convert.ToString(propertySale.soldLink);
            SoldLink = SoldLink.Replace("~", Domain);
            foreach (var sale in propertySale.sales)
                Sales.Add(new Sale(sale));
            MapPosition = new MapPosition(propertySale.mapPosition);


        }
        public string ResidentialArea;
        public string Postal;
        public string City;
        public string Address;
        public string PropertyType;
        public string BbrLink;
        public string SoldLink;
        public List<Sale> Sales = new List<Sale>();
        public MapPosition MapPosition;
        //Also contains a link for adding to wish list but this is left out from datamodel
    }
    public class Sale
    {
        public Sale(dynamic sale)
        {
            SaleDate = sale.saleDate;
            SalePrice = sale.salePrice;
            SaleType = sale.saleType;
        }
        public string SaleDate;
        public string SalePrice;
        public string SaleType;
    }

    public class MapPosition
    {
        public MapPosition(dynamic mapPosition)
        {
            Latitude = mapPosition.latLng.lat;
            Longitude = mapPosition.latLng.lng;
        }
        public string Latitude;
        public string Longitude;
    }
}
