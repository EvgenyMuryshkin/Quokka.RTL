using Newtonsoft.Json;
using Quokka.RTL.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quokka.RTL
{
    public class RTLBitArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(RTLBitArray);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var json = serializer.Deserialize<string>(reader);

            var parts = json?.Split(new[] { ':' });
            if (parts?.Length != 2)
                return null;

            switch(parts[0])
            {
                case "U":
                    return new RTLBitArray(RTLDataType.Unsigned, parts[1], parts[1].Length);
                case "S":
                    return new RTLBitArray(RTLDataType.Signed, parts[1], parts[1].Length);
                default:
                    return null;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var bitArray = (RTLBitArray)value;
            var json = bitArray?.AsJSONValue();
            writer.WriteValue(json);
        }
    }
}
