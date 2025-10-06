using MediatR;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Data.Events.Requests;

namespace Sln.Shared.Data.Events.Handlers;

public abstract class ModelCreateEventHandler<T>: ModelEventHandler<ModelCreateEventRequest<IDataModel>, T>, INotificationHandler<ModelCreateEventRequest<IDataModel>>
{

}