using System.Text.Json.Serialization;
using Sln.Shared.Data.Extensions;
using Sln.Shared.Host.Extensions;
using Mapster;
using Sln.Management.Data;
using Sln.Shared.Common.Constants.Envs;
using Sln.Management.Job;
using Sln.Shared.Data.Interfaces;
using Sln.Management.Business.Services.Realtime;

namespace Sln.Management.KafkaConsumer;

public record Startup(IConfiguration Configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllersWithViews();

        services.AddHttpContextAccessor();
        services.AddHealthChecks();

        // cache define
        services.AddRedisCache();
        services.AddMemoryCacheService();
        services.AddDynamicCacheService();

        // API versioning
        services.AddApiVersion();
        
        services.AddMySqlDb<ManagementDbContext>(
            Environment.GetEnvironmentVariable(EnvConstants.MANAGEMENT_CONNECTION) ?? "",
            "Sln.Management.Migrator"
        );

        services.AddMediatR((configs) =>
        {
            configs.RegisterServicesFromAssemblyContaining<Startup>();
        });

        services.AddControllers()
            .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

        // Background Job
        services.AddScoped(typeof(IJobRepository<>), typeof(JobRepository<>));
        services.AddScoped<IJobUnitOfWork, ManagementJobUnitOfWork>();
        services.AddJobServices();

        // Main Business
        services.AddScoped(typeof(IRepository<>), typeof(ManagementRepository<>));
        services.AddMapster();
        services.AddScoped<IUnitOfWork, ManagementUnitOfWork>();
        services.AddApplicationServices();
        services.AddDomainServices();
        services.AddRelationRepositories();
        services.AddSingleton<RealtimeServices>();
        services.AddHostedService<BackgroundConsumer>();
        services.AddScoped<IUnitOfWork, ManagementUnitOfWork>();
        services.AddKafkaProducerService();
        services.AddKafkaConsumerService();
    }

    public void Configure(IApplicationBuilder app)
    {
        // User have to config Env variable to enable rewrite option
        // REWRITE_LB_ENABLE | {true,false} | default: false | optional
        // REWRITE_LB_PATH | {string} | default: empty | required if REWRITE_LB_ENABLE = true

        app.UseDefaultCorsPolicy();

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

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
        });
    }
}