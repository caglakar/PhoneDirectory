using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactDto:ContactMainListDto
    {   
        //TODO: order base and inherited class properties
        public ICollection<ContactDetailDto> ContactDetails { get; set; } = new List<ContactDetailDto>();
    }
}
