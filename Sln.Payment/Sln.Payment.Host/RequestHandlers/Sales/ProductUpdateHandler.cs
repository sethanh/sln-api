using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductUpdateHandler(ProductService productService) : IRequestHandler<ProductUpdateRequest, ProductUpdateResponse>
{
    public Task<ProductUpdateResponse> Handle(ProductUpdateRequest request, CancellationToken cancellationToken)
    {
        return productService.Update(request);
    }
}