using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq; 
using System.Reflection;
using PhoneDirectory.Services.Contact.Enums;
using System.Collections.Immutable;

namespace PhoneDirectory.Services.Contact.Helpers
{
    public class EnumConverter : JsonConverter
    { 
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;// Buraya girmiyor!
        }

        // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-converters-how-to?pivots=dotnet-5-0#the-use-of-utf8jsonreader-in-the-read-method
        //Steps to follow the basic pattern
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var contactDetailTypeValue = serializer.Deserialize(reader);
            ContactDetailTypes enumValue;

            if (!Enum.TryParse(contactDetailTypeValue.ToString(), out enumValue)
                    && !Enum.TryParse(contactDetailTypeValue.ToString(), ignoreCase: true, out enumValue))
            {
                throw new NotSupportedException("InvalidType");
            }
            return enumValue;

        }

        //https://github.com/dotnet/runtime/blob/81bf79fd9aa75305e55abe2f7e9ef3f60624a3a1/src/libraries/System.Text.Json/src/System/Text/Json/Serialization/Converters/JsonValueConverterBoolean.cs
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //serializer.Serialize(writer, value, value.GetType()); //Çalışmadı!

            writer.WriteValue(value.ToString());
        }


    }
}