using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Business.Services.Realtime;
using MediatR;

namespace Sln.Publisher.Host.RequestHandlers.Realtime.RealtimeItems;

public class RealtimeItemCreateHandler(RealtimeItemService realtimeItemService) : IRequestHandler<RealtimeItemCreateRequest, RealtimeItemCreateResponse>
{
    public Task<RealtimeItemCreateResponse> Handle(RealtimeItemCreateRequest request, CancellationToken cancellationToken)
    {
        return realtimeItemService.Create(request);
    }
}