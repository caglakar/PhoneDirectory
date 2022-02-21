using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Report.Models
{
    public class ContactsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Firm { get; set; }

        public byte IsActive { get; set; }
    }
}
