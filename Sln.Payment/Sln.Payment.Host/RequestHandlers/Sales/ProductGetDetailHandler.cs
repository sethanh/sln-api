using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductGetDetailHandler(ProductService productService) : IRequestHandler<ProductGetDetailRequest, ProductGetDetailResponse>
{
    public Task<ProductGetDetailResponse> Handle(ProductGetDetailRequest request, CancellationToken cancellationToken)
    {
        return productService.GetDetail(request);
    }
}
