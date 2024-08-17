
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Sln.Shared.Business.Interfaces;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Data.Interfaces;
using Sln.Shared.Host.Configurations;

namespace Sln.Shared.Host.Extensions;

public static class ServiceCollectionExtension
{

    public static IServiceCollection AddAssignInterfaceServices<TInterface>(
        this IServiceCollection services
        )
    {
        var appName = Environment.GetEnvironmentVariable(EnvConstants.APP_NAME) ?? throw new Exception("App Name is not set.");
        var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
            .Select(Assembly.Load)
            .Where(a => a.FullName?.StartsWith(appName) ?? false);
        var types = assemblies.SelectMany(a => a.GetExportedTypes());
        var applicationServices = types
            .Where(t => t.IsAssignableTo(typeof(TInterface)) && !t.IsAbstract && !t.IsInterface)
            .ToList();

        foreach (var applicationService in applicationServices)
        {
            services.AddScoped(applicationService);
        }

        return services;
    }

    public static IServiceCollection AddDapperService(this IServiceCollection services)
    {
        return services.AddAssignInterfaceServices<IDapperQuery>();
    }

    public static IServiceCollection AddDomainService(this IServiceCollection services)
    {
        return services.AddAssignInterfaceServices<IDomainService>();
    }

    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
        return services.AddAssignInterfaceServices<IApplicationService>();
    }

    public static IServiceCollection AddCacheService(this IServiceCollection services)
    {
        return services.AddAssignInterfaceServices<ICache>();
    }

    public static IServiceCollection AddReportService(this IServiceCollection services)
    {
        return services.AddAssignInterfaceServices<IReportService>();
    }

    public static IServiceCollection AddRedisCache(this IServiceCollection services)
    {
        var redisConn = Environment.GetEnvironmentVariable("REDIS_CONNECTION");
        var redisInstanceName = Environment.GetEnvironmentVariable("REDIS_INSTANCE_NAME");
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConn;
            options.InstanceName = redisInstanceName;
        });
        return services;
    }

    public static IServiceCollection AddAuthenticationService(this IServiceCollection services)
    {
        var jwtSecret = Environment.GetEnvironmentVariable(EnvConstants.JWT_SECRET);

        if (jwtSecret.IsNullOrEmpty()) { throw new Exception("JWT_SECRET is not set"); }

        services.AddAuthentication(cfg =>
        {
            cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = false;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8
                    .GetBytes(jwtSecret!)
                ),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        }
        ).AddScheme<AuthenticationSchemeOptions, InternalAuthenticationHandler>("InternalAuthentication", null);

        return services;
    }

    public static IServiceCollection AddCurrentAccount(
        this IServiceCollection services
        )
    {
        var appName = Environment.GetEnvironmentVariable(EnvConstants.APP_NAME) ?? throw new Exception("App Name is not set.");

        var assemblies = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(e => 
                e.GetReferencedAssemblies().Select(s => s)
            )
            .Where(a => a.FullName?.StartsWith(appName) ?? false)
            .DistinctBy(e => e.FullName)
            .Select(Assembly.Load);

        var types = assemblies.SelectMany(a => a.GetExportedTypes());

        var currentAccountServices = types
            .Where(t => t.IsAssignableTo(typeof(ICurrentAccount)) && !t.IsAbstract && !t.IsInterface)
            .ToList();


        foreach (var currentAccountService in currentAccountServices)
        {
            services.AddScoped(currentAccountService);
        }

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // Define the BearerAuth scheme
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            // Define the BasicAuth scheme
            c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                Description = "Input your username and password to access this API"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                },
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Basic"
                        }
                    },
                    new List<string>()
                }
            });
        });

        return services;
    }
}
