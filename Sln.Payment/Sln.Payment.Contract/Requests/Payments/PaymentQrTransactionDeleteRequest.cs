using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrTransactionDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}