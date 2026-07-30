using MediatR;
using Sln.Payment.Contract.Requests.Capturess;
using Sln.Payment.Business.Services.Capturess;
using Sln.Payment.Business.ReportServices.Capturess;

namespace Sln.Payment.Host.RequestHandlers.Capturess;

public class CommentGetDetailHandler(CommentService commentService) : IRequestHandler<CommentGetDetailRequest, CommentGetDetailResponse>
{
    public Task<CommentGetDetailResponse> Handle(CommentGetDetailRequest request, CancellationToken cancellationToken)
    {
        return commentService.GetDetail(request);
    }
}
