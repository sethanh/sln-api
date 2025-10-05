using Confluent.Kafka;

namespace Sln.Shared.Common.Interfaces;

public interface IKafkaProducerService
{
    void InitProducerConfig(ProducerConfig config);
    Task PushMessageToTopic<T>(string topic, T data);
}
