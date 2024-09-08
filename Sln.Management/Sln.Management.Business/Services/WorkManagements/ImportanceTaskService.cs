using Sln.Management.Contract.Errors.WorkManagements;
using Sln.Management.Contract.Requests.WorkManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.WorkManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.WorkManagements;

public class ImportanceTaskService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private ImportanceTaskManager ImportanceTaskManager => GetService<ImportanceTaskManager>();

    public Task<ImportanceTaskGetAllResponse> GetAll(ImportanceTaskGetAllRequest request)
    {
        var ImportanceTask = ImportanceTaskManager.GetAll();

        var paginationResponse = PaginationResponse<ImportanceTask>.Create(
            ImportanceTask,
            request
        );

        return Task.FromResult(Mapper.Map<ImportanceTaskGetAllResponse>(paginationResponse));
    }

    public Task<ImportanceTaskGetDetailResponse> GetDetail(ImportanceTaskGetDetailRequest request)
    {
        var importanceTask = ImportanceTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (importanceTask == null)
        {
            throw new HttpNotFound(ImportanceTaskErrors.IMPORTANCE_TASK_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ImportanceTaskGetDetailResponse>(importanceTask));
    }

    public Task<ImportanceTaskCreateResponse> Create(ImportanceTaskCreateRequest request)
    {
        var importanceTask = Mapper.Map<ImportanceTask>(request);

        ImportanceTaskManager.Add(importanceTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<ImportanceTaskCreateResponse>(importanceTask));
    }

    public Task<ImportanceTaskUpdateResponse> Update(ImportanceTaskUpdateRequest request)
    {
        var importanceTask = ImportanceTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if(importanceTask == null)
        {
            throw new HttpBadRequest(ImportanceTaskErrors.IMPORTANCE_TASK_NOT_FOUND);
        }

        // TODO: Update importanceTask properties

        var updatedImportanceTask = ImportanceTaskManager.Update(importanceTask);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<ImportanceTaskUpdateResponse>(updatedImportanceTask));
    }

    public Task Delete(ImportanceTaskDeleteRequest request)
    {
        var importanceTask = ImportanceTaskManager.FirstOrDefault(o => o.Id == request.Id);

        if (importanceTask == null)
        {
            throw new HttpNotFound(ImportanceTaskErrors.IMPORTANCE_TASK_NOT_FOUND);
        }

        ImportanceTaskManager.Delete(importanceTask);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
