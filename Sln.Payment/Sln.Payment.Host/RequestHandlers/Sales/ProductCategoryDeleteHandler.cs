using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCategoryDeleteHandler(ProductCategoryService productCategoryService) : IRequestHandler<ProductCategoryDeleteRequest>
{
    public Task Handle(ProductCategoryDeleteRequest request, CancellationToken cancellationToken)
    {
        return productCategoryService.Delete(request);
    }
}
