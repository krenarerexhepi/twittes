using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitterApp
{
    public class TwitterItem
    {
        public TwitterItem()
        {
            results = new List<results>();
        }

        public string query { get; set; }
        public List<results> results { get; set; }

           }

    public class results
    {
        public Uri profileImageUri
        {
            get
            {
                return new Uri(profile_image_url);
            }
        }

        public string profile_image_url { get; set; }


        public DateTime created_at { get; set; }
        public string from_user { get; set; }
        public string text { get; set; }
        public string from_user_name { get; set; }

        public string fromUserName
        {
            get
            {
                return "  (" + from_user + ")";
            }
        }
    }
}
