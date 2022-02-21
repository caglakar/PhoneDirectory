using System;

namespace PhoneDirectory.Models
{
    public class Contact
    { 
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public virtual string Firm { get; set; }
    }
}
