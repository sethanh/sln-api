using DotNetEnv;
using Sln.Payment.Data;
using Sln.Shared.Migrator;

namespace Sln.Payment.Migrator
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var force = true;
            var host = CreateHostBuilder(args).Build();
            await DbMigrator<PaymentDbContext>.Run(host, force);
            return 0;
        }

        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHostedService<DatabaseStartup<PaymentDbContext>>();
            services.AddDbContext<PaymentDbContext>();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Env.Load();

            return Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureServices(ConfigureServices);
        }
    }
}
