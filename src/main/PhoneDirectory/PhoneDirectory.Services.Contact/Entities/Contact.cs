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

        public byte IsActive { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual ICollection<ContactDetail> ContactDetails { get; set; } = new List<ContactDetail>();
    }
}
