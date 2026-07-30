using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class PostLikeDeleteHandler(PostLikeService postLikeService) : IRequestHandler<PostLikeDeleteRequest>
{
    public Task Handle(PostLikeDeleteRequest request, CancellationToken cancellationToken)
    {
        return postLikeService.Delete(request);
    }
}
