using Sln.Management.Contract.Errors.FinancialManagements;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.FinancialManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.FinancialManagements;

public class FinancialOverviewService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private FinancialOverviewManager FinancialOverviewManager => GetService<FinancialOverviewManager>();

    public Task<FinancialOverviewGetAllResponse> GetAll(FinancialOverviewGetAllRequest request)
    {
        var FinancialOverview = FinancialOverviewManager.GetAll();

        var paginationResponse = PaginationResponse<FinancialOverview>.Create(
            FinancialOverview,
            request
        );

        return Task.FromResult(Mapper.Map<FinancialOverviewGetAllResponse>(paginationResponse));
    }

    public Task<FinancialOverviewGetDetailResponse> GetDetail(FinancialOverviewGetDetailRequest request)
    {
        var financialOverview = FinancialOverviewManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialOverview == null)
        {
            throw new HttpNotFound(FinancialOverviewErrors.FINANCIAL_OVERVIEW_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<FinancialOverviewGetDetailResponse>(financialOverview));
    }

    public Task<FinancialOverviewCreateResponse> Create(FinancialOverviewCreateRequest request)
    {
        var financialOverview = Mapper.Map<FinancialOverview>(request);

        FinancialOverviewManager.Add(financialOverview);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FinancialOverviewCreateResponse>(financialOverview));
    }

    public Task<FinancialOverviewUpdateResponse> Update(FinancialOverviewUpdateRequest request)
    {
        var financialOverview = FinancialOverviewManager.FirstOrDefault(o => o.Id == request.Id);

        if(financialOverview == null)
        {
            throw new HttpBadRequest(FinancialOverviewErrors.FINANCIAL_OVERVIEW_NOT_FOUND);
        }

        // TODO: Update financialOverview properties

        var updatedFinancialOverview = FinancialOverviewManager.Update(financialOverview);

        UnitOfWork.SaveChanges();

        return Task.FromResult(Mapper.Map<FinancialOverviewUpdateResponse>(updatedFinancialOverview));
    }

    public Task Delete(FinancialOverviewDeleteRequest request)
    {
        var financialOverview = FinancialOverviewManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialOverview == null)
        {
            throw new HttpNotFound(FinancialOverviewErrors.FINANCIAL_OVERVIEW_NOT_FOUND);
        }

        FinancialOverviewManager.Delete(financialOverview);

        UnitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}
