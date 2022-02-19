using PhoneDirectory.Services.Contact.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.ValidationAttributes
{
    public class ContactDetailTypeEnumValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var type = (ContactDetailTypes)validationContext.ObjectInstance;

            if (!DoesValueContactDetailTypesEnum(value.ToString()))
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }

        private bool DoesValueContactDetailTypesEnum(string value)
        {
            return Enum.TryParse(typeof(ContactDetailTypes), value, out _);
        }
    }
}
