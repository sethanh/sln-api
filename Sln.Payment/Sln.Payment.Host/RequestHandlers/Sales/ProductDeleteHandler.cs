using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductDeleteHandler(ProductService productService) : IRequestHandler<ProductDeleteRequest>
{
    public Task Handle(ProductDeleteRequest request, CancellationToken cancellationToken)
    {
        return productService.Delete(request);
    }
}
