using Sln.Shared.Data.Events.Requests;
using MediatR;
using Sln.Shared.Data.Interfaces;

namespace Sln.Shared.Data.Events.Handlers;

public abstract class ModelModifyEventHandler<T> : ModelEventHandler<ModelModifyEventRequest<IDataModel>, T>, INotificationHandler<ModelModifyEventRequest<IDataModel>>
{
}