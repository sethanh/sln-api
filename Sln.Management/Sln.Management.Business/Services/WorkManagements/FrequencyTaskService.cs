using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class FrequencyTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private FrequencyTaskManager FrequencyTaskManager => GetService<FrequencyTaskManager>();

    public Task<FrequencyTaskGetAllResponse> GetAll(FrequencyTaskGetAllRequest request)
    {
        var FrequencyTask = FrequencyTaskManager.GetAll();

        var paginationResponse = PaginationResponse<FrequencyTask>.Create(
            FrequencyTask,
            request
        );

        return Task.FromResult(Mapper.Map<FrequencyTaskGetAllResponse>(paginationResponse));
    }

    public Task<FrequencyTaskGetDetailResponse> GetDetail(FrequencyTaskGetDetailRequest request)
    {
        var frequencyTask = FrequencyTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (frequencyTask == null)
        {
            throw new HttpNotFound(FrequencyTaskErrors.FREQUENCY_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<FrequencyTaskGetDetailResponse>(frequencyTask));
    }

    public Task<FrequencyTaskCreateResponse> Create(FrequencyTaskCreateRequest request)
    {
        var frequencyTask = Mapper.Map<FrequencyTask>(request);

        FrequencyTaskManager.Add(frequencyTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FrequencyTaskCreateResponse>(frequencyTask));
    }

    public Task<FrequencyTaskUpdateResponse> Update(FrequencyTaskUpdateRequest request)
    {
        var frequencyTask = FrequencyTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(frequencyTask == null)
        {
            throw new HttpBadRequest(FrequencyTaskErrors.FREQUENCY_TASK_NOT_FOUND);
        }

        // TODO: Update frequencyTask properties

        var updatedFrequencyTask = FrequencyTaskManager.Update(frequencyTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FrequencyTaskUpdateResponse>(updatedFrequencyTask));
    }

    public Task Delete(FrequencyTaskDeleteRequest request)
    {
        var frequencyTask = FrequencyTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (frequencyTask == null)
        {
            throw new HttpNotFound(FrequencyTaskErrors.FREQUENCY_TASK_NOT_FOUND);
        }

        FrequencyTaskManager.Delete(frequencyTask);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
