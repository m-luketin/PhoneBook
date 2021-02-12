using Newtonsoft.Json;
using PhoneBookMobile.Models;
using PhoneBookMobile.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Services
{
    public class ContactService
    {
        private const string endpointUrl = "api/contact/";

        public async Task<List<Contact>> GetAllContacts()
        {
            try
            {
                var responseMessage = await ApiHelper.HttpClient.GetAsync(ApiHelper.BaseUrl + endpointUrl);
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                var stringContent = await responseMessage.Content.ReadAsStringAsync();
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(stringContent);

                return contacts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
