using System.Text;
using System.Text.Json;
using Confluent.Kafka;

namespace Sln.Shared.Common.Values
{
    public class CustomValueDeserializer<T> : IDeserializer<T>
    {
       public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<T>(data)!;
        }
    }
}