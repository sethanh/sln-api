using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class CommentCreateHandler(CommentService commentService) : IRequestHandler<CommentCreateRequest, CommentCreateResponse>
{
    public Task<CommentCreateResponse> Handle(CommentCreateRequest request, CancellationToken cancellationToken)
    {
        return commentService.Create(request);
    }
}