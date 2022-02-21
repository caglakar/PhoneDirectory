
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneDirectory.Models;
using PhoneDirectory.Services.Contact.Consumer.Services;

namespace PhoneDirectory.Services.Contact.Consumer
{
    public class ContactServices : IContactServices
    { 
        private readonly HttpClient client;

        public ContactServices(HttpClient client)
        {
            this.client = client;
        }

        public ContactDto CreateContact(Models.Contact contact)
        {
            var myContent = JsonConvert.SerializeObject(contact);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync($"/api/contacts", byteContent).Result;
            return response.ReadContentAs<ContactDto>();
        }

      
    }
}
