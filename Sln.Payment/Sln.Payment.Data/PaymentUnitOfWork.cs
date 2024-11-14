using Sln.Shared.Data;

namespace Sln.Payment.Data
{
    public class PaymentUnitOfWork(
    PaymentDbContext context
    ) : UnitOfWorkBase<PaymentDbContext>(context)
    {
    }
}