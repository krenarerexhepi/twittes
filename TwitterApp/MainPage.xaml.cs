using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json;
using System.Windows.Media.Imaging;


namespace TwitterApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            MerrFaqenEpare();
        }
        WebClient twitter = new WebClient();
        public void MerrFaqenEpare()
        {
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
            twitter.DownloadStringAsync(new Uri("http://search.twitter.com/search.json?q=100yearsALBANIA:)&rpp=25"));
        }


        public void MerrFaqenTjeter(string faqja)
        {
            twitter.DownloadStringCompleted += new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
            twitter.DownloadStringAsync(new Uri("http://search.twitter.com/search.json?q=100yearsALBANIA:)&rpp=" + faqja));

        }

        TwitterItem lista = new TwitterItem();
        void twitter_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {

            if (e.Error != null || e.Cancelled)
            {
                
                MessageBox.Show("Nuk keni qasje në internet");
                twitter.DownloadStringCompleted -= new DownloadStringCompletedEventHandler(twitter_DownloadStringCompleted);
               


            }
            else
            {
                lista = JsonConvert.DeserializeObject<TwitterItem>(e.Result);
                listBox1.ItemsSource = lista.results;

            }
        }
       

        int nrIFaqes = 50;
        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            string faqja = Convert.ToString(nrIFaqes);
            MerrFaqenTjeter(faqja);
            nrIFaqes = nrIFaqes + 25;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

       
    }
}