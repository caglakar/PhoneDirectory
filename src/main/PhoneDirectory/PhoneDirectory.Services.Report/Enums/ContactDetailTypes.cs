
using System.Text.Json.Serialization;

namespace PhoneDirectory.Services.Report.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ContactDetailTypes
    {
        PhoneNumber,
        Email,
        Location
    }

   
}


