using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Sln.Shared.Common.Values;

namespace Sln.Shared.Common.Interfaces;

public interface IKafkaConsumerService
{
    void InitConsumerConfig(ConsumerConfig config);
    Task SubscribeTopic<T>(string topic, Action<T> callback, CancellationToken cancellationToken);
}
