using System.Text.Json;
using Sln.Shared.Common.Enums.Jobs;
namespace Sln.Shared.Common.Values;

public class KafkaMessage
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? TransactionId { get; set; }
    public string? Data { get; set; }
    public DateTime? SendTime { get; set; }
    public JobEvent? JobEvent { get; set; }
    public long ProcessCount { get; set; } = 0;
    public string? KafkaTopicString { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}