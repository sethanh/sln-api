using Sln.Shared.Host.Extensions;
using Hangfire;
using Hangfire.MySql;
using Sln.Shared.Common.Services;
using Sln.Shared.Common.Abstractions;
using Sln.Shared.Data.Extensions;
using Sln.Scheduler.Data;
using Sln.Scheduler.Data.Extensions;
using Sln.Scheduler.Business.Services;
using Sln.Scheduler.Business.Managers;
using Sln.Scheduler.Data.Abstractions;
using Mapster;
using DotNetEnv;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Data.Interfaces;
using Sln.Scheduler.Host.HangfireFilter;
using Sln.Scheduler.Host.Worker;


namespace Sln.Scheduler.App;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddHealthChecks();

        services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseStorage(
                new MySqlStorage(
                    // "server=192.168.4.110;database=esg_scheduler_dev;user=esg;password=ctnet@@1812;Allow User Variables=True",
                    Environment.GetEnvironmentVariable(EnvConstants.SCHEDULER_CONNECTION),
                    new MySqlStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(3), //check for new jobs in the queues
                        JobExpirationCheckInterval = TimeSpan.FromHours(1), //check and remove for expired jobs
                        CountersAggregateInterval = TimeSpan.FromMinutes(5), //aggregate counter statistics
                        PrepareSchemaIfNecessary = true, //create tables if not exists
                        DashboardJobListLimit = 25000, //limit the number of jobs displayed on dashboard
                        TransactionTimeout = TimeSpan.FromMinutes(1.5), //transaction timeout
                        TablesPrefix = "_",
                    }
                )
            ));

        services.AddMySqlDb<SchedulerDbContext>(services.GetSchedulerConnectionString(),"Sln.Scheduler.Migrator");
        services.AddMediatR((configs) =>
        {
            configs.RegisterServicesFromAssemblyContaining<Startup>();
        });

        // Add the processing server as IHostedService
        services.AddHangfireServer(options => options.WorkerCount = 5);
        services.AddKafkaConsumerService();
        services.AddKafkaProducerService();
        services.AddScoped(typeof(ISchedulerRepository<>), typeof(SchedulerRepository<>));
        services.AddRelationRepositories();
        services.AddScoped<IUnitOfWork, SchedulerUnitOfWork>();
        services.AddMapster();
        services.AddHostedService<BackgroundConsumer>();
        services.AddJobServices();
        services.AddScoped<JobInfoManager>();
        services.AddScoped<JobInfoService>();
    }

    public void Configure(IApplicationBuilder app)
    {
        // User have to config Env variable to enable rewrite option
        // REWRITE_LB_ENABLE | {true,false} | default: false | optional
        // REWRITE_LB_PATH | {string} | default: empty | required if REWRITE_LB_ENABLE = true

        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;
        if (isDevelopment)
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseExceptionHandler(new ExceptionHandlerOptions()
        {
            ExceptionHandlingPath = "/error"
        });

        app.UseHealthChecks("/healthz");

        app.UseHangfireDashboard("", new DashboardOptions
        {
            Authorization = new[] { new HangfireAuthorizationFilter() },
        });
    }
}