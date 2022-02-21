using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Models
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Firm { get; set; }
        public ICollection<ContactDetailDto> ContactDetails { get; set; } = new List<ContactDetailDto>();
    }
}
