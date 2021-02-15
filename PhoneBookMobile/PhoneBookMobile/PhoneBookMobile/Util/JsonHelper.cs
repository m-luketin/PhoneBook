using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMobile.Util
{
    public static class JsonHelper
    {
        public static async Task<StringContent> SerializeAndEncode(object objectToSerialize)
        {
            var serializedObject = JsonConvert.SerializeObject(objectToSerialize);
            var encodedObject = new StringContent(serializedObject, Encoding.UTF8, "application/json");

            return encodedObject;
        }

        public static async Task<T> Deserialize<T>(HttpResponseMessage responseMessage)
        {
            var stringContent = await responseMessage.Content.ReadAsStringAsync();
            var deserializedObject = JsonConvert.DeserializeObject<T>(stringContent);

            return deserializedObject;
        }
    }
}
