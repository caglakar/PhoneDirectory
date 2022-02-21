using PhoneDirectory.Services.Report.Models;
using PhoneDirectory.Services.Report.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Report.Services
{
    public class ContactServices : IContactServices
    { 
        private readonly HttpClient client;

        public ContactServices(HttpClient client)
        {
            this.client = client;
        }

        public IEnumerable<ContactsDto> GetContacts()
        {
            var response = client.GetAsync($"/api/contacts").Result;
            return response.ReadContentAs<List<ContactsDto>>();
        }

        public IEnumerable<ContactDetailDto> GetContactsDetails()
        {
            var response = client.GetAsync($"/api/contacts/details").Result;
            return response.ReadContentAs<List<ContactDetailDto>>();
        }
    }
}
