using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostUpdateHandler(PostService postService) : IRequestHandler<PostUpdateRequest, PostUpdateResponse>
{
    public Task<PostUpdateResponse> Handle(PostUpdateRequest request, CancellationToken cancellationToken)
    {
        return postService.Update(request);
    }
}