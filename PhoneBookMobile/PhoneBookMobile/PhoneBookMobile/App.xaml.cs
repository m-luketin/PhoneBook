using PhoneBookMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhoneBookMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new PhonebookView();
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
