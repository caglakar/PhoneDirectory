using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class LocationDto
    {
        public Guid LocationId { get; set; }
        public string Location { get; set; }
        public int Count { get; set; }
    }
}
