using MediatR;
using Sln.Payment.Contract.Requests.Sales;
using Sln.Payment.Business.Services.Sales;

namespace Sln.Payment.Host.RequestHandlers.Sales;

public class SaleGetAllHandler(SaleService saleService) : IRequestHandler<SaleGetAllRequest, SaleGetAllResponse>
{
    public Task<SaleGetAllResponse> Handle(SaleGetAllRequest request, CancellationToken cancellationToken)
    {
        return saleService.GetAll(request);
    }
}
