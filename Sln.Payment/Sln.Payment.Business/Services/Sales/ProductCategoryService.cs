using Sln.Payment.Contract.Errors.Sales;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Data.Entities;
using Sln.Payment.Business.Managers.Sales;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Contract.Models;
using Sln.Shared.Common.Exceptions;
using Mapster;

namespace Sln.Payment.Business.Services.Sales;

public class ProductCategoryService(IServiceProvider serviceProvider) : PaymentApplicationService(serviceProvider)
{
    private ProductCategoryManager ProductCategoryManager => GetService<ProductCategoryManager>();

    public Task<ProductCategoryGetAllResponse> GetAll(ProductCategoryGetAllRequest request)
    {
        var ProductCategory = ProductCategoryManager.GetAll();

        var paginationResponse = PaginationResponse<ProductCategory>.Create(
            ProductCategory,
            request
        );

        return Task.FromResult(Mapper.Map<ProductCategoryGetAllResponse>(paginationResponse));
    }

    public Task<ProductCategoryGetDetailResponse> GetDetail(ProductCategoryGetDetailRequest request)
    {
        var productCategory = ProductCategoryManager.FirstOrDefault(o => o.Id == request.Id);

        if (productCategory == null)
        {
            throw new HttpNotFound(ProductCategoryErrors.PRODUCT_CATEGORY_NOT_FOUND);
        }

        return Task.FromResult(Mapper.Map<ProductCategoryGetDetailResponse>(productCategory));
    }

    public async Task<ProductCategoryCreateResponse> Create(ProductCategoryCreateRequest request)
    {
        var productCategory = Mapper.Map<ProductCategory>(request);

        ProductCategoryManager.Add(productCategory);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ProductCategoryCreateResponse>(productCategory);
    }

    public async Task<ProductCategoryUpdateResponse> Update(ProductCategoryUpdateRequest request)
    {
        var productCategory = ProductCategoryManager.FirstOrDefault(o => o.Id == request.Id);

        if(productCategory == null)
        {
            throw new HttpBadRequest(ProductCategoryErrors.PRODUCT_CATEGORY_NOT_FOUND);
        }

        // TODO: Update productCategory properties

        var updateProductCategory = request.Adapt(productCategory);

        ProductCategoryManager.Update(updateProductCategory);

        await UnitOfWork.SaveChangesAsync();

        return Mapper.Map<ProductCategoryUpdateResponse>(updateProductCategory);
    }

    public async Task Delete(ProductCategoryDeleteRequest request)
    {
        var productCategory = ProductCategoryManager.FirstOrDefault(o => o.Id == request.Id);

        if (productCategory == null)
        {
            throw new HttpNotFound(ProductCategoryErrors.PRODUCT_CATEGORY_NOT_FOUND);
        }

        ProductCategoryManager.Delete(productCategory);

        await UnitOfWork.SaveChangesAsync();
        return;
    }
}
