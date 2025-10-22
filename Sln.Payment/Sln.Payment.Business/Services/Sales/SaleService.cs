using Sln.Payment.Contract.Errors.Sales;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Sales;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Sales;

public class SaleService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private SaleManager SaleManager => GetService<SaleManager>();

    public Task<SaleGetAllResponse> GetAll(SaleGetAllRequest request)
    {
        var Sale = SaleManager.GetAll();

        var paginationResponse = PaginationResponse<Sale>.Create(
            Sale,
            request
        );

        return Task.FromResult(Mapper.Map<SaleGetAllResponse>(paginationResponse));
    }

    public Task<SaleGetDetailResponse> GetDetail(SaleGetDetailRequest request)
    {
        var sale = SaleManager.FirstOrDefault(o => o.Id == request.Id);

        if (sale == null)
        {
            throw new HttpNotFound(SaleErrors.SALE_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<SaleGetDetailResponse>(sale));
    }

    public async Task<SaleCreateResponse> Create(SaleCreateRequest request)
    {
        var sale = Mapper.Map<Sale>(request);

        SaleManager.Add(sale);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SaleCreateResponse>(sale);
    }

    public async Task<SaleUpdateResponse> Update(SaleUpdateRequest request)
    {
        var sale = SaleManager.FirstOrDefault(o => o.Id == request.Id);

        if(sale == null)
        {
            throw new HttpBadRequest(SaleErrors.SALE_NOT_FOUND);
        }

        // TODO: Update sale properties

        var updateSale = request.Adapt(sale);

        SaleManager.Update(updateSale);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<SaleUpdateResponse>(updateSale);
    }

    public async Task Delete(SaleDeleteRequest request)
    {
        var sale = SaleManager.FirstOrDefault(o => o.Id == request.Id);

        if (sale == null)
        {
            throw new HttpNotFound(SaleErrors.SALE_NOT_FOUND);
        }

        SaleManager.Delete(sale);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
