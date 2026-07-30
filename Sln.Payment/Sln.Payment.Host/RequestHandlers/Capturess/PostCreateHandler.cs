using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostCreateHandler(PostService postService) : IRequestHandler<PostCreateRequest, PostCreateResponse>
{
    public Task<PostCreateResponse> Handle(PostCreateRequest request, CancellationToken cancellationToken)
    {
        return postService.Create(request);
    }
}