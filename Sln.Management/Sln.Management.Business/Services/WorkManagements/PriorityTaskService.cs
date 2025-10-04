using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class PriorityTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private PriorityTaskManager PriorityTaskManager => GetService<PriorityTaskManager>();

    public Task<PriorityTaskGetAllResponse> GetAll(PriorityTaskGetAllRequest request)
    {
        var PriorityTask = PriorityTaskManager.GetAll();

        var paginationResponse = PaginationResponse<PriorityTask>.Create(
            PriorityTask,
            request
        );

        return Task.FromResult(Mapper.Map<PriorityTaskGetAllResponse>(paginationResponse));
    }

    public Task<PriorityTaskGetDetailResponse> GetDetail(PriorityTaskGetDetailRequest request)
    {
        var priorityTask = PriorityTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (priorityTask == null)
        {
            throw new HttpNotFound(PriorityTaskErrors.PRIORITY_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<PriorityTaskGetDetailResponse>(priorityTask));
    }

    public async Task<PriorityTaskCreateResponse> Create(PriorityTaskCreateRequest request)
    {
        var priorityTask = Mapper.Map<PriorityTask>(request);

        PriorityTaskManager.Add(priorityTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PriorityTaskCreateResponse>(priorityTask);
    }

    public async Task<PriorityTaskUpdateResponse> Update(PriorityTaskUpdateRequest request)
    {
        var priorityTask = PriorityTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(priorityTask == null)
        {
            throw new HttpBadRequest(PriorityTaskErrors.PRIORITY_TASK_NOT_FOUND);
        }

        // TODO: Update priorityTask properties

        var updatedPriorityTask = PriorityTaskManager.Update(priorityTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<PriorityTaskUpdateResponse>(updatedPriorityTask);
    }

    public async Task Delete(PriorityTaskDeleteRequest request)
    {
        var priorityTask = PriorityTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (priorityTask == null)
        {
            throw new HttpNotFound(PriorityTaskErrors.PRIORITY_TASK_NOT_FOUND);
        }

        PriorityTaskManager.Delete(priorityTask);

        await UnitOfWork.SaveChangesAsync();
        return ;
    }
}
