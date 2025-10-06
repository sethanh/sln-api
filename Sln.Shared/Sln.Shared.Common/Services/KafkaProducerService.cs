using Confluent.Kafka;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Services;

public class KafkaProducerService : KafkaConnectionChecker, IKafkaProducerService
{
    private ProducerConfig _configProducer = new()
    {
        BootstrapServers = Environment.GetEnvironmentVariable(EnvConstants.KAFKA_BOOTSTRAP_SERVER),
        MessageMaxBytes = 1000000,
        ReceiveMessageMaxBytes = 5000000, // Increase this value as needed
    };

    public void InitProducerConfig(ProducerConfig config)
    {
        _configProducer = config;
    }

    public Task PushMessageToTopic<T>(string topic, T data)
    {
        var topicPrefix = Environment.GetEnvironmentVariable(EnvConstants.KAFKA_TOPIC_PREFIX) ?? throw new ArgumentNullException("KAFKA_TOPIC_PREFIX");
        var topicName = $"{topicPrefix}{topic}";
        
        if(!IsKafkaAvailable(_configProducer.BootstrapServers))
        {
            return Task.CompletedTask;
        }

        using (var producer = new ProducerBuilder<Null, T>(_configProducer)
            .SetValueSerializer(new CustomValueSerializer<T>())
            .Build())
        {
            producer.Produce(topicName, new Message<Null, T> { Value = data },
                (deliveryReport) =>
                {
                    if (deliveryReport.Error.Code != ErrorCode.NoError)
                    {
                        Console.WriteLine($"Failed to deliver message: {deliveryReport.Error.Reason}");
                    }
                });
            producer.Flush(TimeSpan.FromSeconds(10));
        }

        return Task.CompletedTask;
    }
 
}