using Sln.Shared.Common.Abstractions;
using Sln.Shared.Common.Values;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Events.Handlers
{
    public abstract class ModelEventHandler<TU, T> : IEventHandler where TU: EventRequest<IDataModel>
    {
        protected abstract Task Handle(T data, List<AuditDataChange> dataChanges, CancellationToken cancellationToken);
        public async Task Handle(TU notification, CancellationToken cancellationToken)
        {
            if (notification.Data is T data)
            {
                try
                {
                    await Handle(data, notification.DataChanges ?? [], cancellationToken);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}]:{e.Message}");
                }
            }
        }
    }
}