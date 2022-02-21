using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace PhoneDirectory.Services.Contact.Consumer
{
    public static class HttpClientExtension
    { 
        public static T ReadContentAs<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");

            var dataAsString =  response.Content.ReadAsStringAsync().Result;

            return JsonSerializer.Deserialize<T>(dataAsString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
