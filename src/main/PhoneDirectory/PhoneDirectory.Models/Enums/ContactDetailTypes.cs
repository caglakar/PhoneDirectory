
using System.Text.Json.Serialization;

namespace PhoneDirectory.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactDetailTypes
    {
        PhoneNumber,
        Email,
        Location
    }

   
}


