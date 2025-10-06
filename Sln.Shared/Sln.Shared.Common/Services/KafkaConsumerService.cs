using Confluent.Kafka;
using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Services;

public class KafkaConsumerService : KafkaConnectionChecker, IKafkaConsumerService
{
    private ConsumerConfig _configConsumer = new()
    {
        BootstrapServers = Environment.GetEnvironmentVariable(EnvConstants.KAFKA_BOOTSTRAP_SERVER),
        GroupId = Environment.GetEnvironmentVariable(EnvConstants.KAFKA_GROUP_ID),
        AutoOffsetReset = AutoOffsetReset.Earliest,
    };

    public void InitConsumerConfig(ConsumerConfig config)
    {
        _configConsumer = config;
    }

    public Task SubscribeTopic<T>(string topic, Action<T> callback, CancellationToken cancellationToken)
    {
        var topicPrefix = Environment.GetEnvironmentVariable(EnvConstants.KAFKA_TOPIC_PREFIX) ?? throw new ArgumentNullException("KAFKA_TOPIC_PREFIX");
        var topicName = $"{topicPrefix}{topic}";

        try
        {
            using (var consumer = new ConsumerBuilder<Ignore, T>(_configConsumer)
            .SetValueDeserializer(new CustomValueDeserializer<T>())
            .Build())
            {
                consumer.Subscribe(topicName);
                try
                {
                    while (true)
                    {
                        var consumeResult = consumer.Consume(cancellationToken);

                        try
                        {
                            Console.WriteLine($"[{DateTime.Now.ToString()}] Start consuming message: {topicName}");
                            callback(consumeResult.Message.Value);
                            Console.WriteLine($"[{DateTime.Now.ToString()}] Success consuming message: {topicName}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"[{DateTime.Now.ToString()}] Error consuming message: {e.Message}");
                        }

                        if (consumeResult.IsPartitionEOF)
                        {
                            Console.WriteLine($"[{DateTime.Now.ToString()}] Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}.");
                            continue;
                        }

                        // Commit the message to the broker
                        consumer.Commit(consumeResult);
                    }
                }
                catch (OperationCanceledException e)
                {
                    Console.WriteLine($"[{DateTime.Now.ToString()}] Operation canceled: {e.Message}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"[{DateTime.Now.ToString()}] Kafka subscribe fail: {exception.Message}");
                }
                finally
                {
                    consumer.Close();
                }

                Console.WriteLine($"[{DateTime.Now.ToString()}] Fail Connected Kafka and reconnect after 5s");

                Thread.Sleep(5000);

                return SubscribeTopic<T>(topic, callback, cancellationToken);
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine($"[{DateTime.Now.ToString()}] Fail Connected Kafka: {exc.Message})");
            Console.WriteLine($"[{DateTime.Now.ToString()}] Reconnect after 5s");

            Thread.Sleep(5000);

            return SubscribeTopic<T>(topic, callback, cancellationToken);
        }
    }
}