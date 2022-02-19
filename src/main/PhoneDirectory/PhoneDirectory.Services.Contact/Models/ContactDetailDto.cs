using PhoneDirectory.Services.Contact.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactDetailDto
    {
        public Guid Id { get; set; }
        public ContactDetailTypes Type { get; set; }
        public string ContactDetailInfo { get; set; }

    }
}
