using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostDeleteHandler(PostService postService) : IRequestHandler<PostDeleteRequest>
{
    public Task Handle(PostDeleteRequest request, CancellationToken cancellationToken)
    {
        return postService.Delete(request);
    }
}
