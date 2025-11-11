using Sln.Shared.Data;
using Sln.Shared.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Sln.Payment.Data;

public class SchedulerDbContext : DbContextBase
{
    public SchedulerDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.RegisterRelationEntities();
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(255);
        base.ConfigureConventions(configurationBuilder);
    }
}