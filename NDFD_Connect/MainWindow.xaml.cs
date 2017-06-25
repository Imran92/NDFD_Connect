using GoogleMaps.LocationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NDFD_Connect
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double lon;
        public double lat;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            getLongitudeLatitudeFromAddress();
            outputBox.Text = getDataFromNDFDByLongLatAsync();
        }

        private void getLongitudeLatitudeFromAddress()
        {
            var locationService = new GoogleLocationService();
            var address = inputBox.Text;
            var point = locationService.GetLatLongFromAddress(address);

            lat = point.Latitude;
            lon = point.Longitude;
        }

        private string getDataFromNDFDByLongLatAsync()
        {
            WebClient webClient = new WebClient(); //WebRequest.Create("https://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php?lat=" + lat + "&lon=" + lon) as HttpWebRequest;
            //request.UseDefaultCredentials = true;
            webClient.Headers.Add("user-agent", "Only a test!");
            string content = webClient.DownloadString("https://graphical.weather.gov/xml/sample_products/browser_interface/ndfdXMLclient.php?lat=" + lat + "&lon=" + lon);
            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //Stream stream = response.GetResponseStream();
            //return stream.ReadByte().ToString();
            return content;
        }
    }
}
