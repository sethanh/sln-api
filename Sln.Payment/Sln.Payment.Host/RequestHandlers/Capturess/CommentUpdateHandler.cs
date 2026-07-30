using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class CommentUpdateHandler(CommentService commentService) : IRequestHandler<CommentUpdateRequest, CommentUpdateResponse>
{
    public Task<CommentUpdateResponse> Handle(CommentUpdateRequest request, CancellationToken cancellationToken)
    {
        return commentService.Update(request);
    }
}