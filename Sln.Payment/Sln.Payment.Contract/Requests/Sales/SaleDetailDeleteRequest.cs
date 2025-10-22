using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDetailDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}