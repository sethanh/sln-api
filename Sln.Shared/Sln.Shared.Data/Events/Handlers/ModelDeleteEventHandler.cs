using Sln.Shared.Data.Events.Requests;
using MediatR;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Events.Handlers;

public abstract class ModelDeleteEventHandler<T>: ModelEventHandler<ModelDeleteEventRequest<IDataModel>, T>, INotificationHandler<ModelDeleteEventRequest<IDataModel>>
{

}