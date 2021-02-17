using MoneyFlow.Mobile.Commands;
using PhoneBookMobile.Interfaces.Services;
using PhoneBookMobile.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhoneBookMobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Contact> _contacts;
        private readonly IContactService _contactService;

        public ObservableCollection<Contact> Contacts
        {         
            get => _contacts;
            set => SetProperty(ref _contacts, value);
        }

        public ICommand ContactDetailsCommand { get; }


        public MainPageViewModel(INavigationService navigationService, IContactService contactService)
            : base(navigationService)
        {
            Title = "Contacts";
            _contactService = contactService;
            ContactDetailsCommand = new DelegateCommand(NavigateToContactDetails);

            GetData();
        }

        private async Task GetData()
        {
            var contactList = await _contactService.GetAllContacts();
            Contacts = new ObservableCollection<Contact>(contactList);
        }

        private void NavigateToContactDetails()
        {
            NavigationService.NavigateAsync($"/NavigationPage/ContactDetailsPage");
        }
    }
}
