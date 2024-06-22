using DotNetEnv;
using Sln.Management.Data;
using Sln.Shared.Migrator;

namespace Sln.Management.Migrator
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var force = true;
            var host = CreateHostBuilder(args).Build();
            await DbMigrator<ManagementDbContext>.Run(host, force);
            return 0;
        }

        public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHostedService<DatabaseStartup<ManagementDbContext>>();
            services.AddDbContext<ManagementDbContext>();
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
