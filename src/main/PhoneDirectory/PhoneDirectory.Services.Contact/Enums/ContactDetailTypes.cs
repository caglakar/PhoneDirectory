using Newtonsoft.Json;
using PhoneDirectory.Services.Contact.Helpers;

namespace PhoneDirectory.Services.Contact.Enums
{
    [JsonConverter(typeof(EnumConverter))]
    public enum ContactDetailTypes
    {
        PhoneNumber,
        Email,
        Location
    }

   
}


