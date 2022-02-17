using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }
}
