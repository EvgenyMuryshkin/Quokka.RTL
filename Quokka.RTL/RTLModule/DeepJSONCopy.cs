using Newtonsoft.Json;

namespace Quokka.RTL
{
    public class DeepJSONCopy
    {
        static JsonSerializerSettings typeSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects };

        public static string Serialize(object source)
        {
            return JsonConvert.SerializeObject(source, typeSettings);
        }

        public static T DeepCopy<T>(T source)
        {
            var str = JsonConvert.SerializeObject(source, typeSettings);
            return JsonConvert.DeserializeObject<T>(str);
        }
    }
}
