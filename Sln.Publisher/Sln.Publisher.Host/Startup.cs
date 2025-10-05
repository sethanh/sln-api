using Mapster;
using Sln.Publisher.Data;
using StackExchange.Redis;
using Sln.Publisher.Data.Extensions;
using Sln.Publisher.Host.Hubs;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Host.Extensions;
using Sln.Publisher.Business.Services.Realtime;
using Sln.Publisher.Host.Extensions;

namespace Sln.Publisher.Host;

public record Startup(IConfiguration Configuration)
{
    public void
    ConfigureServices(IServiceCollection services)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowFromAll", p =>
            {
                p.SetIsOriginAllowed(o => true);
                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowCredentials();
            });
        });
        services.AddControllersWithViews();
        services.AddHttpContextAccessor();
        services.AddHealthChecks();
        // database define
        services.AddMongoDB<PublisherDbContext>(
            services.GetConnectionString(),
            services.GetMongoDbName()
        );

        // cache define
        services.AddRedisCache(
            "REDIS_CACHE_CONNECTION",
            "REDIS_CACHE_INSTANCE_NAME",
            "REDIS_CACHE_CHANNEL_PREFIX",
            database: 1
        );
        services.AddMemoryCacheService();
        services.AddDynamicCacheService();

        // SignalR raltime define
        services.AddSignalR()
            // Config redis backplane for SignalR using for multiple instance behind load balanacer
            .AddStackExchangeRedis(options =>
            {
                var redisHost = Environment.GetEnvironmentVariable("PUBLISHER_REDIS_CONNECTION") ?? "";
                var redisPort = int.Parse(Environment.GetEnvironmentVariable("PUBLISHER_REDIS_PORT") ?? "6379");
                var redisChannel = Environment.GetEnvironmentVariable("PUBLISHER_REDIS_CHANNEL") ?? "Publisher_Hub";
                options.Configuration.ChannelPrefix = RedisChannel.Literal(redisChannel);
                options.Configuration.DefaultDatabase = 1;
                options.ConnectionFactory = async writer =>
                {
                    var config = new ConfigurationOptions
                    {
                        AbortOnConnectFail = false
                    };
                    config.EndPoints.Add(redisHost, redisPort);
                    config.SetDefaultPorts();
                    var connection = await ConnectionMultiplexer.ConnectAsync(config, writer);
                    connection.ConnectionFailed += (_, e) =>
                    {
                        Console.WriteLine("Connection to Redis failed.");
                    };

                    Console.WriteLine(!connection.IsConnected
                        ? "Did not connect to Redis."
                        : $"Redis connected: {redisHost} - {redisPort}");

                    return connection;
                };
            })
            .AddHubOptions<RealtimeHub>(options =>
            {
                options.MaximumReceiveMessageSize = 1024 * 1024; // 1MB
            });
        services.AddMediatR((configs) =>
        {
            configs.RegisterServicesFromAssemblyContaining<Startup>();
        });

        services.AddMapster();
        services.RegisterMapsterConfiguration();
        services.AddScoped<IUnitOfWork, PublisherUnitOfWork>();
        services.AddApplicationServices();
        services.AddDomainServices();
        services.AddMongoRepositories();
        services.AddSingleton<RealtimeServices>();
        services.AddKafkaConsumerService();
    }

    public void Configure(IApplicationBuilder app)
    {

        var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development;
        if (isDevelopment)
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseExceptionHandler(new ExceptionHandlerOptions()
        {
            ExceptionHandlingPath = "/error"
        });

        app.UseCors("AllowFromAll");
        app.UseHealthChecks("/healthz");
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapDefaultControllerRoute();
            // connect to root realtime hub node
            // Have to call {Subscribe} method to initiate connection listening 
            endpoints.MapHub<RealtimeHub>("/hub/realtime");

            // connect to specific {key} realtime hub node
            // This will auto {Subscribe} {key} node
            // do not need to call {Subscribe} method anymore
            endpoints.MapHub<RealtimeHub>("/hub/realtime/{key}");
        });
    }
}