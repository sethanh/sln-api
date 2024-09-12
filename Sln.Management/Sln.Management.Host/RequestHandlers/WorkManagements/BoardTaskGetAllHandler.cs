using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class BoardTaskGetAllHandler(BoardTaskService boardTaskService) : IRequestHandler<BoardTaskGetAllRequest, BoardTaskGetAllResponse>
{
    public Task<BoardTaskGetAllResponse> Handle(BoardTaskGetAllRequest request, CancellationToken cancellationToken)
    {
        return boardTaskService.GetAll(request);
    }
}
