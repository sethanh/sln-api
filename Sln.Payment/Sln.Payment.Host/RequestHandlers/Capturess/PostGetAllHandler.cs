using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostGetAllHandler(PostService postService) : IRequestHandler<PostGetAllRequest, PostGetAllResponse>
{
    public Task<PostGetAllResponse> Handle(PostGetAllRequest request, CancellationToken cancellationToken)
    {
        return postService.GetAll(request);
    }
}
