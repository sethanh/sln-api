using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Events.Handlers;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Values;

namespace Sln.Management.Host.EventHandlers.AuditLog.System
{
    public class KafkaPushMessageHandler(IServiceProvider ServiceProvider) : KafkaProducerEventHandler<KafkaPublishValue>
    {
        private IKafkaProducerService KafkaProducerService => ServiceProvider.GetRequiredService<IKafkaProducerService>();
        protected override async Task Handle(KafkaPublishValue data, CancellationToken cancellationToken)
        {
            await KafkaProducerService.PushMessageToTopic(data.Topic, data.Message);
        }
    }
}
