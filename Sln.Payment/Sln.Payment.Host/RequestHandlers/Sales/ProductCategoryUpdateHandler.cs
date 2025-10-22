using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCategoryUpdateHandler(ProductCategoryService productCategoryService) : IRequestHandler<ProductCategoryUpdateRequest, ProductCategoryUpdateResponse>
{
    public Task<ProductCategoryUpdateResponse> Handle(ProductCategoryUpdateRequest request, CancellationToken cancellationToken)
    {
        return productCategoryService.Update(request);
    }
}