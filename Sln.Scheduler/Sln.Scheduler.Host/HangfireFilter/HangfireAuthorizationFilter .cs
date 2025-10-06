using Hangfire.Dashboard;

namespace Sln.Scheduler.Host.HangfireFilter;

public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
{
     public bool Authorize(DashboardContext context)
    {
        var httpContext = context.GetHttpContext();

        // Allow all authenticated users to see the Dashboard (potentially dangerous).
        // return httpContext.User.Identity?.IsAuthenticated ?? false;
        return true; // allow all public connection, must be disable for production or implement authenticated
    }
}
