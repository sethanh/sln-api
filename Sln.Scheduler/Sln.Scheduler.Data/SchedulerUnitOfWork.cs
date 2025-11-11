using Sln.Shared.Common.Abstractions;
using Sln.Shared.Data;
using MediatR;

namespace Sln.Payment.Data;

public class SchedulerUnitOfWork(
    SchedulerDbContext context,
    IPublisher publisher
    ) : UnitOfWorkBase<SchedulerDbContext>(context, publisher)
{
}
