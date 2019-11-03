using System;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeCycle
{
    public partial class App : Application
    {
        public static User user;
        public static SqlConnectionStringBuilder connectionInfo = SQLManager.sqlConnectionString("blndhack.database.windows.net", "adminblnd", "Tigerknight!", "HackOhio");

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Login());

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
