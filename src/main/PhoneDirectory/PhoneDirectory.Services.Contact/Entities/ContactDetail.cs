using PhoneDirectory.Services.Contact.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneDirectory.Services.Contact.Entities
{
    public class ContactDetail
    {
        [Key]
        public Guid Id { get; set; }
        public ContactDetailTypes Type { get; set; }
        public string ContactDetailInfo { get; set; }

        [ForeignKey("ContactId")]
        public Contact Contact { get; set; }

        public Guid ContactId { get; set; }
    }
}
