
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Sln.Shared.Data.Abstractions;

namespace Sln.Shared.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRelationRepositories(this IServiceCollection services)
        {
            var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(a => a.FullName?.StartsWith("Esg") ?? false);

            var types = assemblies.SelectMany(a => a.GetExportedTypes());
            var repositoryTypes = types
                .Where(t => t.IsAssignableTo(typeof(IRelationRepository)) && !t.IsAbstract && !t.IsInterface)
                .ToList();

            foreach (var repositoryType in repositoryTypes)
            {
                services.AddScoped(repositoryType);
            }

            return services;
        }

        public static IServiceCollection AddMongoRepositories(this IServiceCollection services)
        {
            var assemblies = Assembly.GetCallingAssembly().GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(a => a.FullName?.StartsWith("Esg") ?? false);

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

        public static void AddMongoDb<TContext>(
            this IServiceCollection services,
            string connectionString,
            string dbName) where TContext : DbContext
        {
            var mongoClient = new MongoClient(connectionString);
            var databaseName = mongoClient.GetDatabase(dbName)
                .DatabaseNamespace
                .DatabaseName;
            services.AddDbContext<TContext>(opt =>
            {
                opt
                    .UseMongoDB(mongoClient, databaseName)
                    .UseSnakeCaseNamingConvention();
            });
        }

        public static void AddMySqlDb<TContext>(
            this IServiceCollection services,
            string connectionString,
            string migrationAssembly
            ) where TContext : DbContext
        {
            // this.MigrationsAssembly = "Esg.Management.Migrator";
            services.AddDbContext<TContext>(optionsBuilder =>
            {
                optionsBuilder.UseSnakeCaseNamingConvention();
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    options =>
                    {
                        options.MigrationsAssembly(migrationAssembly);
                    }
                );
            });
        }

    }
}