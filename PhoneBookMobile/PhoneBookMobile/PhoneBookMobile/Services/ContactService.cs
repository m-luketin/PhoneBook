using Newtonsoft.Json;
using PhoneBookMobile.Interfaces.Services;
using PhoneBookMobile.Models;
using PhoneBookMobile.Util;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Services
{
    public class ContactService : IContactService
    {
        private const string endpointUrl = "/api/contact";

        public async Task<List<Contact>> GetAllContacts()
        {
            try
            {
                var responseMessage = await ApiHelper.HttpClient.GetAsync($"{ApiHelper.BaseUrl}{endpointUrl}");
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<List<Contact>>(responseMessage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> GetContactById(int id)
        {
            try
            {
                var responseMessage = await ApiHelper.HttpClient.GetAsync($"{ApiHelper.BaseUrl}{endpointUrl}/{id}");
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<Contact>(responseMessage); 
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Contact> CreateContact(Contact contactToCreate)
        {
            try
            {
                var serializedContent = JsonHelper.SerializeAndEncode(contactToCreate);

                var responseMessage = await ApiHelper.HttpClient.PostAsync($"{ApiHelper.BaseUrl}{endpointUrl}", serializedContent);
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<Contact>(responseMessage);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> DeleteContact(int id)
        {
            var responseMessage = await ApiHelper.HttpClient.DeleteAsync($"{ApiHelper.BaseUrl}{endpointUrl}/{id}");

            return !responseMessage.IsSuccessStatusCode;
        }

        public async Task<Contact> UpdateContact(Contact contactToUpdate)
        {
            var serializedContent = JsonHelper.SerializeAndEncode(contactToUpdate);

            var responseMessage = await ApiHelper.HttpClient.PutAsync($"{ApiHelper.BaseUrl}{endpointUrl}", serializedContent);
            if (!responseMessage.IsSuccessStatusCode)
                return null;

            return await JsonHelper.Deserialize<Contact>(responseMessage);
        }
    }
}
