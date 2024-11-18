using Newtonsoft.Json;
using System;

namespace Quokka.RTL
{
    public class DeepJSONCopy
    {
        public static JsonSerializerSettings typeSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };
        public static JsonSerializerSettings indentedTypeSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects, Formatting = Formatting.Indented };

        public static string Serialize(object source, JsonSerializerSettings setting = null)
        {
            return JsonConvert.SerializeObject(source, setting ?? typeSettings);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, typeSettings);
        }

        public static object DeserializeType(Type type, string json)
        {
            return JsonConvert.DeserializeObject(json, type, typeSettings);

        }
        public static T DeepCopy<T>(T source)
        {
            var json = Serialize(source);
            return Deserialize<T>(json);
        }

        public static object DeepCopy(Type sourceType, object source)
        {
            var json = Serialize(source);
            return DeserializeType(sourceType, json);
        }
    }
}
