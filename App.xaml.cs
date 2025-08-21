using Xamarin.Forms;

namespace Klarity
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set LoginPage as the initial MainPage
            MainPage = new NavigationPage(new LoginPage());
            

        }

        // Method to switch MainPage after login
        public void NavigateToMainTabbedPage()
        {
            // Set the TabbedPage as the MainPage after login
            MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new HomePage()) { Title = "Home" },
                    new NavigationPage(new ProductSearchPage())  { Title = "Search" },
                    new NavigationPage(new AccountPage())  { Title = "Account" },
                }
            };
        }

        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
       
    }
}