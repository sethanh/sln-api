using Sln.Publisher.Contract.Requests.Realtime.RealtimeItems;
using Sln.Publisher.Business.Services.Realtime;
using MediatR;

namespace Sln.Publisher.Host.RequestHandlers.Realtime.RealtimeItems;

public class RealtimeItemGetDetailHandler(RealtimeItemService realtimeItemService) : IRequestHandler<RealtimeItemGetDetailRequest, RealtimeItemGetDetailResponse>
{
    public Task<RealtimeItemGetDetailResponse> Handle(RealtimeItemGetDetailRequest request, CancellationToken cancellationToken)
    {
        return realtimeItemService.GetDetail(request);
    }
}
