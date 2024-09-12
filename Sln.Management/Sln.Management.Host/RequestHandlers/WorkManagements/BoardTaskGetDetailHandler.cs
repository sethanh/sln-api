using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class BoardTaskGetDetailHandler(BoardTaskService boardTaskService) : IRequestHandler<BoardTaskGetDetailRequest, BoardTaskGetDetailResponse>
{
    public Task<BoardTaskGetDetailResponse> Handle(BoardTaskGetDetailRequest request, CancellationToken cancellationToken)
    {
        return boardTaskService.GetDetail(request);
    }
}
