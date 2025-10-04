using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class RangeTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private RangeTaskManager RangeTaskManager => GetService<RangeTaskManager>();

    public Task<RangeTaskGetAllResponse> GetAll(RangeTaskGetAllRequest request)
    {
        var RangeTask = RangeTaskManager.GetAll();

        var paginationResponse = PaginationResponse<RangeTask>.Create(
            RangeTask,
            request
        );

        return Task.FromResult(Mapper.Map<RangeTaskGetAllResponse>(paginationResponse));
    }

    public Task<RangeTaskGetDetailResponse> GetDetail(RangeTaskGetDetailRequest request)
    {
        var rangeTask = RangeTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (rangeTask == null)
        {
            throw new HttpNotFound(RangeTaskErrors.RANGE_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<RangeTaskGetDetailResponse>(rangeTask));
    }

    public async Task<RangeTaskCreateResponse> Create(RangeTaskCreateRequest request)
    {
        var rangeTask = Mapper.Map<RangeTask>(request);

        RangeTaskManager.Add(rangeTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<RangeTaskCreateResponse>(rangeTask);
    }

    public async Task<RangeTaskUpdateResponse> Update(RangeTaskUpdateRequest request)
    {
        var rangeTask = RangeTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(rangeTask == null)
        {
            throw new HttpBadRequest(RangeTaskErrors.RANGE_TASK_NOT_FOUND);
        }

        // TODO: Update rangeTask properties

        var updatedRangeTask = RangeTaskManager.Update(rangeTask);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<RangeTaskUpdateResponse>(updatedRangeTask);
    }

    public async Task Delete(RangeTaskDeleteRequest request)
    {
        var rangeTask = RangeTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (rangeTask == null)
        {
            throw new HttpNotFound(RangeTaskErrors.RANGE_TASK_NOT_FOUND);
        }

        RangeTaskManager.Delete(rangeTask);

        await UnitOfWork.SaveChangesAsync();
        return ;
    }
}
