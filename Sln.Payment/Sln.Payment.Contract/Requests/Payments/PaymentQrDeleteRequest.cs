using Sln.Shared.Contract.Models;
using MediatR;

namespace Sln.Payment.Contract.Requests.Payments;

public class PaymentQrDeleteRequest : IRequest
{
    public Guid Id { get; set; }
}