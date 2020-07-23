using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using expensessApp.Views;

namespace expensessApp
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public App() : this(string.Empty)
        {

        }
                  
        public App(string databasePath)
        {
            InitializeComponent();
            DatabasePath = databasePath;

            MainPage = new NavigationPage(new MainPage());
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
