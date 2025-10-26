using System.Reflection;
using Asp.Versioning;
using Sln.Shared.Common.Enums.Cache;
using Sln.Shared.Common.Services;
using Sln.Shared.Data.Abstractions;
using Sln.Shared.Host.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver.Linq;
using StackExchange.Redis;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Constants.Envs;

namespace Sln.Shared.Host.Extensions;

public static class ServiceProviderExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(a => a.FullName?.StartsWith("Sln") ?? false);
        var types = assemblies.SelectMany(a => a.GetExportedTypes());
        var applicationServices = types
            .Where(t => t.IsAssignableTo(typeof(IApplicationService)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var applicationService in applicationServices)
        {
            services.AddScoped(applicationService);
        }

        return services;
    }

    public static IServiceCollection AddJobServices(this IServiceCollection services)
    {
        var callingAssembly = Assembly.GetCallingAssembly();
        var assemblies = callingAssembly
            .GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(a => a.FullName?.StartsWith("Sln") ?? false);
        var types = assemblies.SelectMany(a => a.GetExportedTypes()).Concat(callingAssembly.GetExportedTypes());
        var applicationServices = types
            .Where(t => t.IsAssignableTo(typeof(IJobService)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var applicationService in applicationServices)
        {
            services.AddScoped(applicationService);
        }

        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(a => a.FullName?.StartsWith("Sln") ?? false);

        var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToArray();
        var domainServices = types
            .Where(t => t.IsAssignableTo(typeof(Business.Interfaces.IDomainService)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var domainService in domainServices)
        {
            services.AddScoped(domainService);
        }

        // Dynamic register scoped service without specific add one by one
        var scopedServices = types.Where(e => e.IsAssignableTo(typeof(IScopedService)) && !e.IsAbstract && !e.IsInterface)
            .ToList();

        foreach (var scopedService in scopedServices)
        {
            services.AddScoped(scopedService);
        }

        services.AddMediatrHandler(types);
        return services;
    }

    public static IServiceCollection AddApiVersion(this IServiceCollection services, ApiVersion? defaultApiVersion = null)
    {
        services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers
                    // "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = defaultApiVersion ?? new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                })
            .AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        return services;
    }

    public static IServiceCollection AddKafkaConsumerService(this IServiceCollection services)
    {
        services.AddSingleton<IKafkaConsumerService, KafkaConsumerService>();
        return services;
    }

    public static IServiceCollection AddKafkaProducerService(this IServiceCollection services)
    {
        services.AddScoped<IKafkaProducerService, KafkaProducerService>();
        return services;
    }

    public static IServiceCollection AddRedisCache(this IServiceCollection services)
    {
        return services.AddRedisCache(
            Environment.GetEnvironmentVariable(EnvConstants.REDIS_CACHE_CONNECTION) ?? "",
            Environment.GetEnvironmentVariable(EnvConstants.REDIS_CACHE_INSTANCE_NAME) ?? "",
            Environment.GetEnvironmentVariable(EnvConstants.REDIS_CACHE_CHANNEL_PREFIX) ?? "",
            database: 1
        );
    }

    public static IServiceCollection AddRedisCache(this IServiceCollection services,
        string connection,
        string instanceName = "default",
        string channelPrefix = "RedisCache",
        int database = 0)
    {

        services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = instanceName;
            options.ConfigurationOptions = new ConfigurationOptions()
            {
                EndPoints = new EndPointCollection() { connection },
                DefaultDatabase = database,
                ChannelPrefix = RedisChannel.Literal(channelPrefix)
            };
        });
        services.AddScoped<IRedisCacheService, RedisCacheService>();
        return services;
    }

    public static IServiceCollection AddMemoryCacheService(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddScoped<IMemoryCacheService, MemoryCacheService>();
        return services;
    }

    public static void AddDynamicCacheService(this IServiceCollection services)
    {
        services.AddScoped<Func<CacheType, ICacheService>>(sp => (type) =>
        {
            ICacheService? cacheService = null;
            if (type == CacheType.Memory) return sp.GetService<IMemoryCacheService>()!;
            if (type == CacheType.Redis)
            {
                cacheService = sp.GetService<IRedisCacheService>();
            }

            if (cacheService == null)
            {
                cacheService = sp.GetService<IMemoryCacheService>();
            }

            return cacheService!;
        });
    }


    public static string GetEnv(this IServiceCollection services, string envKey)
    {
        var env = Environment.GetEnvironmentVariable(envKey);
        if (string.IsNullOrEmpty(env))
        {
            throw new Exception($"Environment variable {envKey} was not set");
        }
        return env;
    }

    public static void AddMediatrHandler(this IServiceCollection services, IEnumerable<Type> types)
    {
        var eventHandlerServices = types
            .Where(t => t.IsAssignableTo(typeof(IEventHandler)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var mediatr in eventHandlerServices)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssemblyContaining(mediatr));
        }
    }
    
     public static IServiceCollection AddMongoRepositories(this IServiceCollection services)
    {
        var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(a => a.FullName?.StartsWith("Sln") ?? false);
            
        var types = assemblies.SelectMany(a => a.GetExportedTypes());
        var checkType = types.Select(s => new
        {
            s.Name,
            s.Namespace,
            s.FullName,
            isRepo = s.IsAssignableTo(typeof(IMongoRepository)),
            s.IsAbstract,
            s.IsInterface,
            s
        }).ToList();
        var repositoryTypes = types
            .Where(t => t.IsAssignableTo(typeof(IMongoRepository)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var repositoryType in repositoryTypes)
        {
            services.AddScoped(repositoryType);
        }

        return services;
    }
}
