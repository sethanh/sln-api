using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostLikeGetDetailHandler(PostLikeService postLikeService) : IRequestHandler<PostLikeGetDetailRequest, PostLikeGetDetailResponse>
{
    public Task<PostLikeGetDetailResponse> Handle(PostLikeGetDetailRequest request, CancellationToken cancellationToken)
    {
        return postLikeService.GetDetail(request);
    }
}
