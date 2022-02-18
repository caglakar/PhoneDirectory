using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Services.Contact.Entities
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public string Firm { get; set; }

        public ICollection<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();
    }
}
