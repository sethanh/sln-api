using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class BoardTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private BoardTaskManager BoardTaskManager => GetService<BoardTaskManager>();

    public Task<BoardTaskGetAllResponse> GetAll(BoardTaskGetAllRequest request)
    {
        var BoardTask = BoardTaskManager.GetAll();

        var paginationResponse = PaginationResponse<BoardTask>.Create(
            BoardTask,
            request
        );

        return Task.FromResult(Mapper.Map<BoardTaskGetAllResponse>(paginationResponse));
    }

    public Task<BoardTaskGetDetailResponse> GetDetail(BoardTaskGetDetailRequest request)
    {
        var boardTask = BoardTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (boardTask == null)
        {
            throw new HttpNotFound(BoardTaskErrors.BOARD_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<BoardTaskGetDetailResponse>(boardTask));
    }

    public Task<BoardTaskCreateResponse> Create(BoardTaskCreateRequest request)
    {
        var boardTask = Mapper.Map<BoardTask>(request);

        BoardTaskManager.Add(boardTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<BoardTaskCreateResponse>(boardTask));
    }

    public Task<BoardTaskUpdateResponse> Update(BoardTaskUpdateRequest request)
    {
        var boardTask = BoardTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(boardTask == null)
        {
            throw new HttpBadRequest(BoardTaskErrors.BOARD_TASK_NOT_FOUND);
        }

        // TODO: Update boardTask properties

        var updatedBoardTask = BoardTaskManager.Update(boardTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<BoardTaskUpdateResponse>(updatedBoardTask));
    }

    public Task Delete(BoardTaskDeleteRequest request)
    {
        var boardTask = BoardTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (boardTask == null)
        {
            throw new HttpNotFound(BoardTaskErrors.BOARD_TASK_NOT_FOUND);
        }

        BoardTaskManager.Delete(boardTask);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
