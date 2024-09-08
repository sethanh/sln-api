using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class TaskManagementService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private TaskManagementManager TaskManagementManager => GetService<TaskManagementManager>();

    public Task<TaskManagementGetAllResponse> GetAll(TaskManagementGetAllRequest request)
    {
        var TaskManagement = TaskManagementManager.GetAll();

        var paginationResponse = PaginationResponse<TaskManagement>.Create(
            TaskManagement,
            request
        );

        return Task.FromResult(Mapper.Map<TaskManagementGetAllResponse>(paginationResponse));
    }

    public Task<TaskManagementGetDetailResponse> GetDetail(TaskManagementGetDetailRequest request)
    {
        var taskManagement = TaskManagementManager.FirstOrDefault(o => o.Id == request.Id);

        if (taskManagement == null)
        {
            throw new HttpNotFound(TaskManagementErrors.TASK_MANAGEMENT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<TaskManagementGetDetailResponse>(taskManagement));
    }

    public Task<TaskManagementCreateResponse> Create(TaskManagementCreateRequest request)
    {
        var taskManagement = Mapper.Map<TaskManagement>(request);

        TaskManagementManager.Add(taskManagement);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<TaskManagementCreateResponse>(taskManagement));
    }

    public Task<TaskManagementUpdateResponse> Update(TaskManagementUpdateRequest request)
    {
        var taskManagement = TaskManagementManager.FirstOrDefault(o => o.Id == request.Id);

        if(taskManagement == null)
        {
            throw new HttpBadRequest(TaskManagementErrors.TASK_MANAGEMENT_NOT_FOUND);
        }

        // TODO: Update taskManagement properties

        var updatedTaskManagement = TaskManagementManager.Update(taskManagement);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<TaskManagementUpdateResponse>(updatedTaskManagement));
    }

    public Task Delete(TaskManagementDeleteRequest request)
    {
        var taskManagement = TaskManagementManager.FirstOrDefault(o => o.Id == request.Id);

        if (taskManagement == null)
        {
            throw new HttpNotFound(TaskManagementErrors.TASK_MANAGEMENT_NOT_FOUND);
        }

        TaskManagementManager.Delete(taskManagement);

        UnitOfWork.SaveChanges();

        return Task.CompletedTask;
    }
}
