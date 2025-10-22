using Sln.Payment.Contract.Errors.Sales;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Sales;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Sales;

public class SaleDetailService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private SaleDetailManager SaleDetailManager => GetService<SaleDetailManager>();

    public Task<SaleDetailGetAllResponse> GetAll(SaleDetailGetAllRequest request)
    {
        var SaleDetail = SaleDetailManager.GetAll();

        var paginationResponse = PaginationResponse<SaleDetail>.Create(
            SaleDetail,
            request
        );

        return Task.FromResult(Mapper.Map<SaleDetailGetAllResponse>(paginationResponse));
    }

    public Task<SaleDetailGetDetailResponse> GetDetail(SaleDetailGetDetailRequest request)
    {
        var saleDetail = SaleDetailManager.FirstOrDefault(o => o.Id == request.Id);

        if (saleDetail == null)
        {
            throw new HttpNotFound(SaleDetailErrors.SALE_DETAIL_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<SaleDetailGetDetailResponse>(saleDetail));
    }

    public async Task<SaleDetailCreateResponse> Create(SaleDetailCreateRequest request)
    {
        var saleDetail = Mapper.Map<SaleDetail>(request);

        SaleDetailManager.Add(saleDetail);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SaleDetailCreateResponse>(saleDetail);
    }

    public async Task<SaleDetailUpdateResponse> Update(SaleDetailUpdateRequest request)
    {
        var saleDetail = SaleDetailManager.FirstOrDefault(o => o.Id == request.Id);

        if(saleDetail == null)
        {
            throw new HttpBadRequest(SaleDetailErrors.SALE_DETAIL_NOT_FOUND);
        }

        // TODO: Update saleDetail properties

        var updateSaleDetail = request.Adapt(saleDetail);

        SaleDetailManager.Update(updateSaleDetail);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SaleDetailUpdateResponse>(updateSaleDetail);
    }

    public async Task Delete(SaleDetailDeleteRequest request)
    {
        var saleDetail = SaleDetailManager.FirstOrDefault(o => o.Id == request.Id);

        if (saleDetail == null)
        {
            throw new HttpNotFound(SaleDetailErrors.SALE_DETAIL_NOT_FOUND);
        }

        SaleDetailManager.Delete(saleDetail);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
