using AutoMapper;

namespace PhoneDirectory.Services.Contact.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Entities.Contact, Models.ContactDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{ src.FirstName} {src.LastName}"));
           
            CreateMap<Models.ContactCreationDto, Entities.Contact>();

            CreateMap<Models.ContactUpdateDto, Entities.Contact>();
        }
    }
}
