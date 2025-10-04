using Sln.Management.Contract.Errors.FinancialManagements;
using Sln.Management.Contract.Requests.FinancialManagements;
using Sln.Management.Data.Entities;
using Sln.Management.Business.Managers.FinancialManagements;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;

namespace Sln.Management.Business.Services.FinancialManagements;

public class FinancialExpenditureService(IServiceProvider serviceProvider) : ManagementApplicationService(serviceProvider)
{
    private FinancialExpenditureManager FinancialExpenditureManager => GetService<FinancialExpenditureManager>();

    public Task<FinancialExpenditureGetAllResponse> GetAll(FinancialExpenditureGetAllRequest request)
    {
        var FinancialExpenditure = FinancialExpenditureManager.GetAll();

        var paginationResponse = PaginationResponse<FinancialExpenditure>.Create(
            FinancialExpenditure,
            request
        );

        return Task.FromResult(Mapper.Map<FinancialExpenditureGetAllResponse>(paginationResponse));
    }

    public Task<FinancialExpenditureGetDetailResponse> GetDetail(FinancialExpenditureGetDetailRequest request)
    {
        var financialExpenditure = FinancialExpenditureManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialExpenditure == null)
        {
            throw new HttpNotFound(FinancialExpenditureErrors.FINANCIAL_EXPENDITURE_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<FinancialExpenditureGetDetailResponse>(financialExpenditure));
    }

    public async Task<FinancialExpenditureCreateResponse> Create(FinancialExpenditureCreateRequest request)
    {
        var financialExpenditure = Mapper.Map<FinancialExpenditure>(request);

        FinancialExpenditureManager.Add(financialExpenditure);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<FinancialExpenditureCreateResponse>(financialExpenditure);
    }

    public async Task<FinancialExpenditureUpdateResponse> Update(FinancialExpenditureUpdateRequest request)
    {
        var financialExpenditure = FinancialExpenditureManager.FirstOrDefault(o => o.Id == request.Id);

        if(financialExpenditure == null)
        {
            throw new HttpBadRequest(FinancialExpenditureErrors.FINANCIAL_EXPENDITURE_NOT_FOUND);
        }

        // TODO: Update financialExpenditure properties

        var updatedFinancialExpenditure = FinancialExpenditureManager.Update(financialExpenditure);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<FinancialExpenditureUpdateResponse>(updatedFinancialExpenditure);
    }

    public async Task Delete(FinancialExpenditureDeleteRequest request)
    {
        var financialExpenditure = FinancialExpenditureManager.FirstOrDefault(o => o.Id == request.Id);

        if (financialExpenditure == null)
        {
            throw new HttpNotFound(FinancialExpenditureErrors.FINANCIAL_EXPENDITURE_NOT_FOUND);
        }

        FinancialExpenditureManager.Delete(financialExpenditure);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
