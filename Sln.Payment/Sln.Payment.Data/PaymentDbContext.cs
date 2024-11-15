using Microsoft.EntityFrameworkCore;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Data;
using Sln.Shared.Data.Extensions;

namespace Sln.Payment.Data
{
    public class PaymentDbContext : DbContextBase
    {
        public PaymentDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            this.ConnectionString = GetConnectionString();
            this.MigrationAssembly = "Sln.Payment.Migrator";
        }

        public static string GetConnectionString()
        {
            var connectionName = EnvConstants.PAYMENT_CONNECTION;
            if (string.IsNullOrEmpty(connectionName))
            {
                throw new Exception($"Connection name environment variable is not set.");
            }
            var connectionString = Environment.GetEnvironmentVariable(connectionName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"Connection value environment variable is not set.");
            }

            return connectionString;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.RegisterAllEntities();
            base.OnModelCreating(builder);
        }
        
    }
}