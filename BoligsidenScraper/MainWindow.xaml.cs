using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BoligsidenScraper.Scrapers.Searchsite;
using Newtonsoft.Json;

namespace BoligsidenScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        private async void On_Button_Run_Clicked(object sender, RoutedEventArgs e)
        {
            var municipalities = Municipalities.MunicipalityCollection;

            foreach(string municipality in municipalities)
            {
                var handler = new SearchSiteHandler(municipality);

                List<PropertySale> sales = await handler.GetAllPropertySales();
                
                //Turn to json string
                string json = JsonConvert.SerializeObject(sales.ToArray(),Formatting.Indented);

                //Write json to file
                string fileDirectory = AssemblyDirectory + "\\kommuner";
                string completeFilePath = fileDirectory + "\\" + municipality + ".json";
                Directory.CreateDirectory(fileDirectory);
                File.WriteAllText(completeFilePath, json);
            }

        


        }
    }
}
