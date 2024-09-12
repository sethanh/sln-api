using Sln.Management.Contract.Errors.FinancialManagements;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.FinancialManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.FinancialManagements;

public class FinancialEpicService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private FinancialEpicManager FinancialEpicManager => GetService<FinancialEpicManager>();

    public Task<FinancialEpicGetAllResponse> GetAll(FinancialEpicGetAllRequest request)
    {
        var FinancialEpic = FinancialEpicManager.GetAll();

        var paginationResponse = PaginationResponse<FinancialEpic>.Create(
            FinancialEpic,
            request
        );

        return Task.FromResult(Mapper.Map<FinancialEpicGetAllResponse>(paginationResponse));
    }

    public Task<FinancialEpicGetDetailResponse> GetDetail(FinancialEpicGetDetailRequest request)
    {
        var financialEpic = FinancialEpicManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialEpic == null)
        {
            throw new HttpNotFound(FinancialEpicErrors.FINANCIAL_EPIC_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<FinancialEpicGetDetailResponse>(financialEpic));
    }

    public Task<FinancialEpicCreateResponse> Create(FinancialEpicCreateRequest request)
    {
        var financialEpic = Mapper.Map<FinancialEpic>(request);

        FinancialEpicManager.Add(financialEpic);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FinancialEpicCreateResponse>(financialEpic));
    }

    public Task<FinancialEpicUpdateResponse> Update(FinancialEpicUpdateRequest request)
    {
        var financialEpic = FinancialEpicManager.FirstOrDefault(o => o.Id == request.Id);

        if(financialEpic == null)
        {
            throw new HttpBadRequest(FinancialEpicErrors.FINANCIAL_EPIC_NOT_FOUND);
        }

        // TODO: Update financialEpic properties

        var updatedFinancialEpic = FinancialEpicManager.Update(financialEpic);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FinancialEpicUpdateResponse>(updatedFinancialEpic));
    }

    public Task Delete(FinancialEpicDeleteRequest request)
    {
        var financialEpic = FinancialEpicManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialEpic == null)
        {
            throw new HttpNotFound(FinancialEpicErrors.FINANCIAL_EPIC_NOT_FOUND);
        }

        FinancialEpicManager.Delete(financialEpic);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
