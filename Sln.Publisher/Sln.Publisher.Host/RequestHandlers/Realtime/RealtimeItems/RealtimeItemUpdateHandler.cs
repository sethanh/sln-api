using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Business.Services.Realtime;
using MediatR;

namespace Sln.Publisher.Host.RequestHandlers.Realtime.RealtimeItems;

public class RealtimeItemUpdateHandler(RealtimeItemService realtimeItemService) : IRequestHandler<RealtimeItemUpdateRequest, RealtimeItemUpdateResponse>
{
    public Task<RealtimeItemUpdateResponse> Handle(RealtimeItemUpdateRequest request, CancellationToken cancellationToken)
    {
        return realtimeItemService.Update(request);
    }
}