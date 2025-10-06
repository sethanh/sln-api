using Sln.Shared.Common.Interfaces;

namespace Sln.Shared.Common.Values
{
    public class KafkaPublishValue : IKafkaProducerEvent
    {
        public required string Topic { get; set; }
        public required KafkaMessage Message { get; set; }
    }
}