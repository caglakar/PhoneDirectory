using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public abstract class ContactMainDto
    {
        [Required(ErrorMessage = "FirstName is required.")]
        [MaxLength(50, ErrorMessage = "FirstName shouldn't have more than 50 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required.")]
        [MaxLength(50, ErrorMessage = "LastName shouldn't have more than 50 characters.")]
        public string LastName { get; set; }

        public virtual string Firm { get; set; }
    }
}
