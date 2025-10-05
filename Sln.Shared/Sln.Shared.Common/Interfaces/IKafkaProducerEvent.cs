using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Interfaces
{
    public interface IKafkaProducerEvent
    {
        string Topic { get; set; }
        KafkaMessage Message { get; set; }
    }
}