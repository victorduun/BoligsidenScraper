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
using System.Windows.Controls;
namespace BoligsidenScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
           
        public class TextboxText
        {
            public string textdata { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
            InfoText.DataContext = new TextboxText() { textdata = JsonDirectory + "\\[Municipality].json" };
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> options = new List<string>();
            options.Add("All");
            foreach (var option in Municipalities.MunicipalityCollection)
                options.Add(option);
            cmbMunicipalityList.ItemsSource = options;
            cmbMunicipalityList.Text = "Choose municipality.";
        }

        public static string JsonDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path) + "\\kommuner";
            }
        }



        private async void On_Button_Run_Clicked(object sender, RoutedEventArgs e)
        {

            Directory.CreateDirectory(JsonDirectory);

            List<string> municipalitiesToCheck = new List<string>();

            string selectedItem = Convert.ToString(cmbMunicipalityList.SelectedItem);
            //Check if valid municipality
            if(selectedItem == "All")
                municipalitiesToCheck = Municipalities.MunicipalityCollection.ToList();
            else if(String.IsNullOrEmpty(selectedItem))
            {
                MessageBox.Show("No municipality selected.", "Error");
                return;
            }
            else
            {
                if (Municipalities.MunicipalityCollection.Contains(selectedItem))
                    municipalitiesToCheck.Add(selectedItem);
                else
                {
                    MessageBox.Show("Invalid municipality.", "Error");
                    return;
                }
            }

            Run.IsEnabled = false;

            foreach (string municipality in municipalitiesToCheck)
            {
                ProgressTextBox.Text = "Scraping data for municipality: " + municipality;
                var handler = new SearchSiteHandler(municipality);

                List<PropertySale> sales = await handler.GetAllPropertySales();

                //Turn to json string
                string json = JsonConvert.SerializeObject(sales.ToArray(),Formatting.Indented);

                //Write json to file
                string completeFilePath = JsonDirectory + "\\" + municipality + ".json";
                File.WriteAllText(completeFilePath, json);
            }

            Run.IsEnabled = true;
            ProgressTextBox.Text = "Ready to start data scraping.";
            MessageBox.Show("Finished scraping data for municipality: " + selectedItem, "Complete");

        }
    }
}
