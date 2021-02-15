using PhoneBookMobile.Models;
using PhoneBookMobile.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Services
{
    public class PhoneNumberService
    {
        private const string endpointUrl = "api/phone-number/";

        public async Task<List<PhoneNumber>> GetAllPhoneNumbers()
        {
            try
            {
                var responseMessage = await ApiHelper.HttpClient.GetAsync(ApiHelper.BaseUrl + endpointUrl);
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<List<PhoneNumber>>(responseMessage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PhoneNumber> GetPhoneNumberById(int id)
        {
            try
            {
                var responseMessage = await ApiHelper.HttpClient.GetAsync($"{ApiHelper.BaseUrl}{endpointUrl}/{id}");
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<PhoneNumber>(responseMessage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PhoneNumber> CreatePhoneNumber(PhoneNumber phoneNumberToCreate)
        {
            try
            {
                var serializedContent = await JsonHelper.SerializeAndEncode(phoneNumberToCreate);

                var responseMessage = await ApiHelper.HttpClient.PostAsync($"{ApiHelper.BaseUrl}{endpointUrl}", serializedContent);
                if (!responseMessage.IsSuccessStatusCode)
                    return null;

                return await JsonHelper.Deserialize<PhoneNumber>(responseMessage);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeletePhoneNumber(int id)
        {
            var responseMessage = await ApiHelper.HttpClient.DeleteAsync($"{ApiHelper.BaseUrl}{endpointUrl}/{id}");

            return !responseMessage.IsSuccessStatusCode;
        }

        public async Task<PhoneNumber> UpdatePhoneNumber(PhoneNumber phoneNumberToUpdate)
        {
            var serializedContent = await JsonHelper.SerializeAndEncode(phoneNumberToUpdate);

            var responseMessage = await ApiHelper.HttpClient.PutAsync($"{ApiHelper.BaseUrl}{endpointUrl}", serializedContent);
            if (!responseMessage.IsSuccessStatusCode)
                return null;

            return await JsonHelper.Deserialize<PhoneNumber>(responseMessage);
        }
    }
}
