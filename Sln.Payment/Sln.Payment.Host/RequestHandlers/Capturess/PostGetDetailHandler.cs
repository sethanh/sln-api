using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostGetDetailHandler(PostService postService) : IRequestHandler<PostGetDetailRequest, PostGetDetailResponse>
{
    public Task<PostGetDetailResponse> Handle(PostGetDetailRequest request, CancellationToken cancellationToken)
    {
        return postService.GetDetail(request);
    }
}
