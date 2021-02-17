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
        public const string BaseUrl = "https://192.168.43.149:5001"; 
        public static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (o, cert, chain, errors) => true
        });
    }
}
