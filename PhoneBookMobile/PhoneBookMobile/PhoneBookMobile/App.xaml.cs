using Prism.Ioc;
using Prism;
using Prism.DryIoc;
using Xamarin.Forms;
using PhoneBookMobile.Services;
using Prism.Navigation;
using PhoneBookMobile.Interfaces.Services;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace PhoneBookMobile
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IContactService, ContactService>();
            containerRegistry.Register<IPhoneNumberService, PhoneNumberService>();
        }
    }
}
