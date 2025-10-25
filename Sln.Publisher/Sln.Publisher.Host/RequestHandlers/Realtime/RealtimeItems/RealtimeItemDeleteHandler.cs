using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Business.Services.Realtime;
using MediatR;

namespace Sln.Publisher.Host.RequestHandlers.Realtime.RealtimeItems;

public class RealtimeItemDeleteHandler(RealtimeItemService realtimeItemService) : IRequestHandler<RealtimeItemDeleteRequest, RealtimeItemRemoveResponse>
{
    public Task<RealtimeItemRemoveResponse> Handle(RealtimeItemDeleteRequest request, CancellationToken cancellationToken)
    {
        return realtimeItemService.Delete(request);
    }
}
