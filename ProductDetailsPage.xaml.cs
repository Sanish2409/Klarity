using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Klarity
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }
        public ObservableCollection<Item> AmazonCategories { get; set; }

        public ProductDetailsPage()
        {
            InitializeComponent();

            AmazonCategories = new ObservableCollection<Item>
            {
                new Item { Name = "Men's", ImageSource = "amazon_men" },
                new Item { Name = "Women's", ImageSource = "amazon_women" },
                new Item { Name = "Electronics", ImageSource = "amazon_electronics" },
                new Item { Name = "Sneakers", ImageSource = "amazon_sneakers" }
            };

            Products = new ObservableCollection<Product>
            {
                new Product { Name = "Dell inspiron 14", ImageUrl = "dell", Price = "$999.99" },
                new Product { Name = "Aldo-Jacket", ImageUrl = "aldo", Price = "$115" },
                new Product { Name = "Ps5", ImageUrl = "bestbuy_console1", Price = "$455" },
                new Product { Name = "Jbl charge 5", ImageUrl = "jbl", Price = "$230" },
                new Product { Name = "chino pant", ImageUrl = "chino", Price = "$45" },
                new Product { Name = "42 inch TV-for home and small theatre", ImageUrl = "bestbuy_tv", Price = "$200" },
                // Add more products here...
            };
            

            BindingContext = this;
        }
    }
    public class Product
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
    }
}