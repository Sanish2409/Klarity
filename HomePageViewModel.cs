using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Klarity
{
    public class HomePageViewModel
    {
        public ObservableCollection<string> ImageList { get; set; }

        public HomePageViewModel()
        {
            ImageList = new ObservableCollection<string>
        {
            "offer2.jpg",
            "offer3.jpg",
            "offer4.jpg"
        };
        }
    }
}