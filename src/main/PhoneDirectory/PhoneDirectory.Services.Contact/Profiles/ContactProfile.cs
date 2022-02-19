using AutoMapper;

namespace PhoneDirectory.Services.Contact.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            #region To not duplicate concatenation of Name propertiess
            // Firstname ve lasname birleşimini tüm inherited classlarda kullanabilmek için
            //https://docs.automapper.org/en/stable/Mapping-inheritance.html?highlight=reverse%20property


            CreateMap<Entities.Contact, Models.ContactMainListDto>()
                .Include<Entities.Contact, Models.ContactsDto>()
                .Include<Entities.Contact, Models.ContactDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{ src.FirstName} {src.LastName}"));

            CreateMap<Entities.Contact, Models.ContactsDto>();
            CreateMap<Entities.Contact, Models.ContactDto>();
            #endregion

            CreateMap<Models.ContactCreationDto, Entities.Contact>();

            CreateMap<Models.ContactUpdateDto, Entities.Contact>();
        }
    }
}
