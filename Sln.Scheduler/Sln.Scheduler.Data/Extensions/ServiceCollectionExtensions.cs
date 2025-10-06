using Sln.Shared.Common.Constants;
using Microsoft.Extensions.DependencyInjection;
using Sln.Shared.Common.Constants.Envs;

namespace Sln.Scheduler.Data.Extensions;

public static class ServiceCollectionExtensions
{
    public static string GetSchedulerConnectionString(this IServiceCollection services)
    {
        var connectionString = Environment.GetEnvironmentVariable(EnvConstants.SCHEDULER_CONNECTION);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception($"{EnvConstants.SCHEDULER_CONNECTION} environment variable is not set.");
        }

        return connectionString;
    }
    
}