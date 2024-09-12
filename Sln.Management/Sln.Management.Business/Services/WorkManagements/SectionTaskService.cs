using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class SectionTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private SectionTaskManager SectionTaskManager => GetService<SectionTaskManager>();

    public Task<SectionTaskGetAllResponse> GetAll(SectionTaskGetAllRequest request)
    {
        var SectionTask = SectionTaskManager.GetAll();

        var paginationResponse = PaginationResponse<SectionTask>.Create(
            SectionTask,
            request
        );

        return Task.FromResult(Mapper.Map<SectionTaskGetAllResponse>(paginationResponse));
    }

    public Task<SectionTaskGetDetailResponse> GetDetail(SectionTaskGetDetailRequest request)
    {
        var sectionTask = SectionTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (sectionTask == null)
        {
            throw new HttpNotFound(SectionTaskErrors.SECTION_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<SectionTaskGetDetailResponse>(sectionTask));
    }

    public Task<SectionTaskCreateResponse> Create(SectionTaskCreateRequest request)
    {
        var sectionTask = Mapper.Map<SectionTask>(request);

        SectionTaskManager.Add(sectionTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<SectionTaskCreateResponse>(sectionTask));
    }

    public Task<SectionTaskUpdateResponse> Update(SectionTaskUpdateRequest request)
    {
        var sectionTask = SectionTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(sectionTask == null)
        {
            throw new HttpBadRequest(SectionTaskErrors.SECTION_TASK_NOT_FOUND);
        }

        // TODO: Update sectionTask properties

        var updatedSectionTask = SectionTaskManager.Update(sectionTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<SectionTaskUpdateResponse>(updatedSectionTask));
    }

    public Task Delete(SectionTaskDeleteRequest request)
    {
        var sectionTask = SectionTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (sectionTask == null)
        {
            throw new HttpNotFound(SectionTaskErrors.SECTION_TASK_NOT_FOUND);
        }

        SectionTaskManager.Delete(sectionTask);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
