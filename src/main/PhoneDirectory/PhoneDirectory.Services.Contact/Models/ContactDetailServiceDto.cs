using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactDetailServiceDto:ContactDetailMainDto
    {
        public Guid ContactId { get; set; }
    }
}
