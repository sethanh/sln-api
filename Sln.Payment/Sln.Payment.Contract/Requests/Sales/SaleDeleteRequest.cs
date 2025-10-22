using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Sales;

public class SaleDeleteRequest: IRequest
{
    public Guid Id { get; set; }
}