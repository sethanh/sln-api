using MediatR;
using Sln.Shared.Data;

namespace Sln.Payment.Data
{
    public class PaymentUnitOfWork(
    PaymentDbContext context,
    IPublisher publisher
    ) : UnitOfWorkBase<PaymentDbContext>(context, publisher)
    {
    }
}