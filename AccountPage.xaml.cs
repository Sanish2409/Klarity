using Klarity.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Klarity
{
    public partial class AccountPage : ContentPage
    {
       

        public AccountPage()
        {
            InitializeComponent();
            BindingContext = new AccountPageViewModel();
        }
        private async void OnSignOutClicked(object sender, EventArgs e)
        {
            bool isConfirmed = await DisplayAlert("Sign Out", "Are you sure you want to sign out?", "Yes", "No");
            if (isConfirmed)
            {
                // Reset MainPage to LoginPage
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
        // You can add Clicked event handlers to handle each action
    }
}


