using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostLikeGetAllHandler(PostLikeService postLikeService) : IRequestHandler<PostLikeGetAllRequest, PostLikeGetAllResponse>
{
    public Task<PostLikeGetAllResponse> Handle(PostLikeGetAllRequest request, CancellationToken cancellationToken)
    {
        return postLikeService.GetAll(request);
    }
}
