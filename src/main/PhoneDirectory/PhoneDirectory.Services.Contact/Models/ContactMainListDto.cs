using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public abstract class ContactMainListDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Firm { get; set; }
    }
}
