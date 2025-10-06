using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Common.Constants.Envs;

namespace Sln.Publisher.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static string GetConnectionString(this IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable(EnvConstants.PUBLISHER_CONNECTION);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception($"PUBLISHER_CONNECTION environment variable is not set.");
            }

            return connectionString;
        }
        public static string GetMongoDbName(this IServiceCollection services)
        {
            var dbName = Environment.GetEnvironmentVariable(EnvConstants.PUBLISHER_MONGODB);
            if (string.IsNullOrEmpty(dbName))
            {
                throw new Exception($"PUBLISHER_MONGODB environment variable is not set.");
            }

            return dbName;
        }
    }
}