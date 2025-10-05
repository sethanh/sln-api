using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data;
using Sln.Shared.Data.Extensions;

namespace Sln.Publisher.Data;

public class PublisherDbContext : DbContextBase
{
    public PublisherDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.RegisterMongoEntities();
    }
}
