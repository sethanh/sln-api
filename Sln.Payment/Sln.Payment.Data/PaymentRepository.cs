using Sln.Payment.Common.Models;
using Sln.Payment.Data.Attributes;
using Sln.Shared.Common.Extensions;
using Sln.Shared.Data;
using Sln.Shared.Data.Interfaces;
using System.Linq.Expressions;

namespace Sln.Payment.Data
{
    public class PaymentRepository<TEntity>(
        PaymentDbContext context,
        CurrentPaymentAccount currentAccount
        ) : RepositoryBase<TEntity, Guid>(context, currentAccount.Id), IRepository<TEntity> where TEntity : class
    {
    }

}
