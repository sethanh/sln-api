using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductCreateHandler(ProductService productService) : IRequestHandler<ProductCreateRequest, ProductCreateResponse>
{
    public Task<ProductCreateResponse> Handle(ProductCreateRequest request, CancellationToken cancellationToken)
    {
        return productService.Create(request);
    }
}