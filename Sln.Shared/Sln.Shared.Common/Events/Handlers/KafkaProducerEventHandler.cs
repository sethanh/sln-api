using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Events.Requests;
using MediatR;
using Sln.Shared.Common.Interfaces;

namespace Sln.Shared.Common.Events.Handlers
{
    public abstract class KafkaProducerEventHandler<T> : INotificationHandler<KafkaProducerEventRequest<IKafkaProducerEvent>>
    {
        protected abstract Task Handle(T data, CancellationToken cancellationToken);

        public async Task Handle(KafkaProducerEventRequest<IKafkaProducerEvent> notification, CancellationToken cancellationToken)
        {
            if (notification.Data is T data)
            {
                try
                {
                    await Handle(data, cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}]:{e.Message}");
                }
            }
        }
    }
}