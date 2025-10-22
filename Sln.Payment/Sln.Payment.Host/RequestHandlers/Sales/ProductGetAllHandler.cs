using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class ProductGetAllHandler(ProductService productService) : IRequestHandler<ProductGetAllRequest, ProductGetAllResponse>
{
    public Task<ProductGetAllResponse> Handle(ProductGetAllRequest request, CancellationToken cancellationToken)
    {
        return productService.GetAll(request);
    }
}
