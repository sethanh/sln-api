using Confluent.Kafka;
using Confluent.Kafka.Admin;
using System;
using System.Threading.Tasks;

public class KafkaConnectionChecker
{
    public static bool IsKafkaAvailable(string bootstrapServers)
    {
        var config = new AdminClientConfig
        {
            BootstrapServers = bootstrapServers,
            SocketTimeoutMs = 3000  // Set a short timeout for quick feedback
        };

        using var adminClient = new AdminClientBuilder(config).Build();

        try
        {
            // List topics to check connectivity
            var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(5));
            // If no exception is thrown, Kafka is available
            return true;
        }
        catch (KafkaException e)
        {
            Console.WriteLine($"Kafka connection test failed: {e.Message}");
            return false;
        }
    }
}