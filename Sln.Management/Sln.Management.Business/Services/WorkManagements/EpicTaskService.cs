using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class EpicTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private EpicTaskManager EpicTaskManager => GetService<EpicTaskManager>();

    public Task<EpicTaskGetAllResponse> GetAll(EpicTaskGetAllRequest request)
    {
        var EpicTask = EpicTaskManager.GetAll();

        var paginationResponse = PaginationResponse<EpicTask>.Create(
            EpicTask,
            request
        );

        return Task.FromResult(Mapper.Map<EpicTaskGetAllResponse>(paginationResponse));
    }

    public Task<EpicTaskGetDetailResponse> GetDetail(EpicTaskGetDetailRequest request)
    {
        var epicTask = EpicTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (epicTask == null)
        {
            throw new HttpNotFound(EpicTaskErrors.EPIC_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<EpicTaskGetDetailResponse>(epicTask));
    }

    public Task<EpicTaskCreateResponse> Create(EpicTaskCreateRequest request)
    {
        var epicTask = Mapper.Map<EpicTask>(request);

        EpicTaskManager.Add(epicTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<EpicTaskCreateResponse>(epicTask));
    }

    public Task<EpicTaskUpdateResponse> Update(EpicTaskUpdateRequest request)
    {
        var epicTask = EpicTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(epicTask == null)
        {
            throw new HttpBadRequest(EpicTaskErrors.EPIC_TASK_NOT_FOUND);
        }

        // TODO: Update epicTask properties

        var updatedEpicTask = EpicTaskManager.Update(epicTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<EpicTaskUpdateResponse>(updatedEpicTask));
    }

    public Task Delete(EpicTaskDeleteRequest request)
    {
        var epicTask = EpicTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (epicTask == null)
        {
            throw new HttpNotFound(EpicTaskErrors.EPIC_TASK_NOT_FOUND);
        }

        EpicTaskManager.Delete(epicTask);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
