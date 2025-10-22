using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDeleteHandler(SaleService saleService) : IRequestHandler<SaleDeleteRequest>
{
    public Task Handle(SaleDeleteRequest request, CancellationToken cancellationToken)
    {
        return saleService.Delete(request);
    }
}
