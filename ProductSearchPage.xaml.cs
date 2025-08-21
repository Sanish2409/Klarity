using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Klarity
{
    public partial class ProductSearchPage : ContentPage
    {
        public class Product
        {
            public string ProductName { get; set; }
            public string ProductDetails { get; set; }
        }

        public ProductSearchPage()
        {
            InitializeComponent();
        }



        // Handle Google search
        private void OnGoogleSearch(object sender, EventArgs e)
        {
            string query = GoogleSearchBar.Text;

            if (!string.IsNullOrWhiteSpace(query))
            {
                // Create the Google Search URL
                string googleSearchUrl = $"https://www.google.com/search?q={Uri.EscapeUriString(query)}";

                // Load the search result in WebView
                GoogleWebView.Source = googleSearchUrl;
            }
        }
    }
}
