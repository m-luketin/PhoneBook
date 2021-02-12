using Newtonsoft.Json;
using PhoneBookMobile.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Util
{
    public static class ApiHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true
        });
        private const string baseUrl = "https://f7aca47c2b5a.ngrok.io"; 
        private const string contactEndpoint = "/api/contact/";
        private const string phoneNumberEndpoint = "/api/phonenumber/";

        public static async Task<List<Contact>> GetAllContacts()
        {
            try
            {
                var responseMessage = await _httpClient.GetAsync(baseUrl + contactEndpoint);
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
