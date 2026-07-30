using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class CommentGetAllHandler(CommentService commentService) : IRequestHandler<CommentGetAllRequest, CommentGetAllResponse>
{
    public Task<CommentGetAllResponse> Handle(CommentGetAllRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetAll(request);
    }
}
