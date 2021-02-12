using PhoneBookMobile.Views;
using PhoneBookMobile.Util;
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
            TestRequest();
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

        private async void TestRequest()
        {
            var contacts = await ApiHelper.GetAllContacts();
        }
    }
}
