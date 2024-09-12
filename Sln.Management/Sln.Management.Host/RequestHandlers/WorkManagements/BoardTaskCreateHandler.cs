using MediatR;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Business.Services.WorkManagements;

namespace Sln.Management.Host.RequestHandlers.WorkManagements;

public class BoardTaskCreateHandler(BoardTaskService boardTaskService) : IRequestHandler<BoardTaskCreateRequest, BoardTaskCreateResponse>
{
    public Task<BoardTaskCreateResponse> Handle(BoardTaskCreateRequest request, CancellationToken cancellationToken)
    {
        return boardTaskService.Create(request);
    }
}