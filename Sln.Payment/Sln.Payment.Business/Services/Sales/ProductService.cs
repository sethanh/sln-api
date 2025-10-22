using Sln.Payment.Contract.Errors.Sales;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Sales;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Sales;

public class ProductService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ProductManager ProductManager => GetService<ProductManager>();

    public Task<ProductGetAllResponse> GetAll(ProductGetAllRequest request)
    {
        var Product = ProductManager.GetAll();

        var paginationResponse = PaginationResponse<Product>.Create(
            Product,
            request
        );

        return Task.FromResult(Mapper.Map<ProductGetAllResponse>(paginationResponse));
    }

    public Task<ProductGetDetailResponse> GetDetail(ProductGetDetailRequest request)
    {
        var product = ProductManager.FirstOrDefault(o => o.Id == request.Id);

        if (product == null)
        {
            throw new HttpNotFound(ProductErrors.PRODUCT_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ProductGetDetailResponse>(product));
    }

    public async Task<ProductCreateResponse> Create(ProductCreateRequest request)
    {
        var product = Mapper.Map<Product>(request);

        ProductManager.Add(product);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ProductCreateResponse>(product);
    }

    public async Task<ProductUpdateResponse> Update(ProductUpdateRequest request)
    {
        var product = ProductManager.FirstOrDefault(o => o.Id == request.Id);

        if(product == null)
        {
            throw new HttpBadRequest(ProductErrors.PRODUCT_NOT_FOUND);
        }

        // TODO: Update product properties

        var updateProduct = request.Adapt(product);

        ProductManager.Update(updateProduct);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ProductUpdateResponse>(updateProduct);
    }

    public async Task Delete(ProductDeleteRequest request)
    {
        var product = ProductManager.FirstOrDefault(o => o.Id == request.Id);

        if (product == null)
        {
            throw new HttpNotFound(ProductErrors.PRODUCT_NOT_FOUND);
        }

        ProductManager.Delete(product);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
