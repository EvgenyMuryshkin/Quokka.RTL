using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quokka.RTL.Tools;
using System;
using System.Linq;
using System.Reflection;

namespace Quokka.RTL
{
    public class RTLMemoryBlockConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return  objectType != null && 
                    objectType.IsConstructedGenericType && 
                    objectType.GetGenericTypeDefinition() == typeof(RTLMemoryBlock<>);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue == null)
            {
                ConstructorInfo ctor = objectType.GetConstructor(new[] { typeof(int) });
                existingValue = ctor.Invoke(new object[] { 0 });

                //var ctor = objectType.GetConstructors().Where(c => c.GetParameters().FirstOrDefault()?.ParameterType == typeof(int));
                //ctor.
                //existingValue = Activator.CreateInstance(objectType, new[] { 0 });
            }
            var memoryBlock = existingValue as IRTLMemoryBlock;

            var serialized = serializer.Deserialize(reader, memoryBlock.SerializedType());
            memoryBlock.FromSerialized(serialized);

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var memoryBlock = value as IRTLMemoryBlock;
            serializer.Serialize(writer, memoryBlock.ToSerialized());
        }
    }
}
