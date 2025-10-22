using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCategoryGetAllHandler(ProductCategoryService productCategoryService) : IRequestHandler<ProductCategoryGetAllRequest, ProductCategoryGetAllResponse>
{
    public Task<ProductCategoryGetAllResponse> Handle(ProductCategoryGetAllRequest request, CancellationToken cancellationToken)
    {
        return productCategoryService.GetAll(request);
    }
}
