using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Business.Services.Realtime;
using MediatR;

namespace Sln.Publisher.Host.RequestHandlers.Realtime.RealtimeItems;

public class RealtimeItemGetAllHandler(RealtimeItemService realtimeItemService) : IRequestHandler<RealtimeItemGetAllRequest, RealtimeItemGetAllResponse>
{
    public Task<RealtimeItemGetAllResponse> Handle(RealtimeItemGetAllRequest request, CancellationToken cancellationToken)
    {
        return realtimeItemService.GetAll(request);
    }
}
