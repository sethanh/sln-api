using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class CommentDeleteHandler(CommentService commentService) : IRequestHandler<CommentDeleteRequest>
{
    public Task Handle(CommentDeleteRequest request, CancellationToken cancellationToken)
    {
        return commentService.Delete(request);
    }
}
