using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostLikeCreateHandler(PostLikeService postLikeService) : IRequestHandler<PostLikeCreateRequest, PostLikeCreateResponse>
{
    public Task<PostLikeCreateResponse> Handle(PostLikeCreateRequest request, CancellationToken cancellationToken)
    {
        return postLikeService.Create(request);
    }
}