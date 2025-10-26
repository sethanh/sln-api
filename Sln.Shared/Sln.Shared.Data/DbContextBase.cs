using Microsoft.EntityFrameworkCore;
using Sln.Shared.Data.Extensions;

namespace Sln.Shared.Data
{
    public abstract class DbContextBase(DbContextOptions dbContextOptions) : DbContext(dbContextOptions) 
    {
        public string? ConnectionString { get; set; }
        public string? MigrationAssembly { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if(optionsBuilder.IsConfigured)
            {
                return;
            }

            // optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql(
                this.ConnectionString,
                ServerVersion.AutoDetect(this.ConnectionString),
                optionsBuilder => 
                {
                    optionsBuilder.MigrationsAssembly(this.MigrationAssembly);
                }
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.RegisterAllEntities();
        }
    }
}