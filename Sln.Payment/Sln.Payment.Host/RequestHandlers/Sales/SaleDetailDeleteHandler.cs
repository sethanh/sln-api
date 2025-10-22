using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleDetailDeleteHandler(SaleDetailService saleDetailService) : IRequestHandler<SaleDetailDeleteRequest>
{
    public Task Handle(SaleDetailDeleteRequest request, CancellationToken cancellationToken)
    {
        return saleDetailService.Delete(request);
    }
}
