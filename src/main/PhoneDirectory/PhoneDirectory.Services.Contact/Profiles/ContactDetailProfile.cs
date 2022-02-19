using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Contact.Profiles
{
    public class ContactDetailProfile : Profile
    {
        public ContactDetailProfile()
        { 
            CreateMap<Models.ContactDetailCreateDto, Entities.ContactDetail>();

            CreateMap<Entities.ContactDetail, Models.ContactDetailDto>();
            
        }

    }
}
