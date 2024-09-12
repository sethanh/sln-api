using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class BoardTaskUpdateHandler(BoardTaskService boardTaskService) : IRequestHandler<BoardTaskUpdateRequest, BoardTaskUpdateResponse>
{
    public Task<BoardTaskUpdateResponse> Handle(BoardTaskUpdateRequest request, CancellationToken cancellationToken)
    {
        return boardTaskService.Update(request);
    }
}