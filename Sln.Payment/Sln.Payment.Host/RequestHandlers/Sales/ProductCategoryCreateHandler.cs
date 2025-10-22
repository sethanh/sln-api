using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCategoryCreateHandler(ProductCategoryService productCategoryService) : IRequestHandler<ProductCategoryCreateRequest, ProductCategoryCreateResponse>
{
    public Task<ProductCategoryCreateResponse> Handle(ProductCategoryCreateRequest request, CancellationToken cancellationToken)
    {
        return productCategoryService.Create(request);
    }
}