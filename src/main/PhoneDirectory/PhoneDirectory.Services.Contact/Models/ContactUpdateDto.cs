using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Models
{
    public class ContactUpdateDto:ContactMainDto
    {
        [Required(ErrorMessage = "Firm needs to be filled.")]
        public override string Firm { get => base.Firm; set => base.Firm = value; }
    }
}
