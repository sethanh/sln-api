using Sln.Shared.Data.Extensions;
using Sln.Shared.Migrator;
using Sln.Scheduler.Data;
using Sln.Shared.Common.Constants.Envs;
using DotNetEnv;

namespace Sln.Scheduler.Migrator;

class Program
{
    public static async Task<int> Main(string[] args)
    {
        var force = args.Contains("--force");

        var host = CreateHostBuilder(args).Build();
        await DbMigrator<SchedulerDbContext>.Run(host, force);
        return 0;
    }

    public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        services.AddMySqlDb<SchedulerDbContext>(
            Environment.GetEnvironmentVariable(EnvConstants.SCHEDULER_CONNECTION) ?? "",
            "Sln.Scheduler.Migrator"
        );
        services.AddHostedService<DatabaseStartup<SchedulerDbContext>>();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        Env.Load();

        return Host
            .CreateDefaultBuilder(args)
            .UseConsoleLifetime()
            .ConfigureServices(ConfigureServices);
    }
}