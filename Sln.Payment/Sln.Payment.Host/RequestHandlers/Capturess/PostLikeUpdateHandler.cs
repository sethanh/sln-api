using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostLikeUpdateHandler(PostLikeService postLikeService) : IRequestHandler<PostLikeUpdateRequest, PostLikeUpdateResponse>
{
    public Task<PostLikeUpdateResponse> Handle(PostLikeUpdateRequest request, CancellationToken cancellationToken)
    {
        return postLikeService.Update(request);
    }
}