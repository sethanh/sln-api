using Sln.Shared.Data;
using MediatR;
namespace Sln.Publisher.Data;

public class PublisherUnitOfWork(
    PublisherDbContext context,
    IPublisher publisher
    ) : UnitOfWorkBase<PublisherDbContext>(context, publisher)
{
}