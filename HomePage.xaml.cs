using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;


namespace Klarity
{
    public partial class HomePage : ContentPage
    {
        
        public ObservableCollection<Item> AmazonCategories { get; set; }
        public ObservableCollection<Item> EbayCategories { get; set; }
        public ObservableCollection<Item> BestBuyCategories { get; set; }
        public ObservableCollection<Item> SheinCategories { get; set; }
       

        public HomePage()
        {
            InitializeComponent();
           


            // Sample data with ImageSource as local resources (images placed in Resources/drawable for Android)
            AmazonCategories = new ObservableCollection<Item>
            {
                new Item { Name = "Men's", ImageSource = "amazon_men" },
                new Item { Name = "Women's", ImageSource = "amazon_women" },
                new Item { Name = "Electronics", ImageSource = "amazon_electronics" },
                new Item { Name = "Sneakers", ImageSource = "amazon_sneakers" }
            };

            EbayCategories = new ObservableCollection<Item>
            {
                new Item { Name = "Men's", ImageSource = "ebay_men" },
                new Item { Name = "Women's", ImageSource = "ebay_women" },
                new Item { Name = "Electronics", ImageSource = "ebay_electronics" }
            };

            BestBuyCategories = new ObservableCollection<Item>
            {
                new Item { Name = "TVs", ImageSource = "bestbuy_tv" },
                new Item { Name = "Laptops", ImageSource = "bestbuy_laptop" },
                new Item { Name = "Consoles", ImageSource = "bestbuy_console1" }
            };

            SheinCategories = new ObservableCollection<Item>
            {
                new Item { Name = "Men's", ImageSource = "shein_men" },
                new Item { Name = "Women's", ImageSource = "shein_women" },
                new Item { Name = "Beauty", ImageSource = "shein_beauty" }
            };
             
            BindingContext = this;
            
        }
        private async void OnSeeMoreAmazonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductDetailsPage());
        }

       

       
    }


}
