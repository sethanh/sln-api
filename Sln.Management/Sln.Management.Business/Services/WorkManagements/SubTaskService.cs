using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class SubTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private SubTaskManager SubTaskManager => GetService<SubTaskManager>();

    public Task<SubTaskGetAllResponse> GetAll(SubTaskGetAllRequest request)
    {
        var SubTask = SubTaskManager.GetAll();

        var paginationResponse = PaginationResponse<SubTask>.Create(
            SubTask,
            request
        );

        return Task.FromResult(Mapper.Map<SubTaskGetAllResponse>(paginationResponse));
    }

    public Task<SubTaskGetDetailResponse> GetDetail(SubTaskGetDetailRequest request)
    {
        var subTask = SubTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (subTask == null)
        {
            throw new HttpNotFound(SubTaskErrors.SUB_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<SubTaskGetDetailResponse>(subTask));
    }

    public async Task<SubTaskCreateResponse> Create(SubTaskCreateRequest request)
    {
        var subTask = Mapper.Map<SubTask>(request);

        SubTaskManager.Add(subTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SubTaskCreateResponse>(subTask);
    }

    public async Task<SubTaskUpdateResponse> Update(SubTaskUpdateRequest request)
    {
        var subTask = SubTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(subTask == null)
        {
            throw new HttpBadRequest(SubTaskErrors.SUB_TASK_NOT_FOUND);
        }

        // TODO: Update subTask properties

        var updatedSubTask = SubTaskManager.Update(subTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SubTaskUpdateResponse>(updatedSubTask);
    }

    public async Task Delete(SubTaskDeleteRequest request)
    {
        var subTask = SubTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (subTask == null)
        {
            throw new HttpNotFound(SubTaskErrors.SUB_TASK_NOT_FOUND);
        }

        SubTaskManager.Delete(subTask);

        await UnitOfWork.SaveChangesAsync();
        return ;
    }
}
