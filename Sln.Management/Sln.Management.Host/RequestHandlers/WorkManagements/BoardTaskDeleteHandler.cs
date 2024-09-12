using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class BoardTaskDeleteHandler(BoardTaskService boardTaskService) : IRequestHandler<BoardTaskDeleteRequest>
{
    public Task Handle(BoardTaskDeleteRequest request, CancellationToken cancellationToken)
    {
        return boardTaskService.Delete(request);
    }
}
