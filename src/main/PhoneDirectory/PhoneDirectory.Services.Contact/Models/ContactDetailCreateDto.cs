using PhoneDirectory.Services.Contact.Enums;
using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactDetailCreateDto
    {
        [Required]
        public ContactDetailTypes Type { get; set; }
        public string ContactDetailInfo { get; set; }
    }
}
