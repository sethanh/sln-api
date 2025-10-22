using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCategoryGetDetailHandler(ProductCategoryService productCategoryService) : IRequestHandler<ProductCategoryGetDetailRequest, ProductCategoryGetDetailResponse>
{
    public Task<ProductCategoryGetDetailResponse> Handle(ProductCategoryGetDetailRequest request, CancellationToken cancellationToken)
    {
        return productCategoryService.GetDetail(request);
    }
}
