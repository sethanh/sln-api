using System.Text.Json;
using Sln.Shared.Common.Constants;
using Sln.Shared.Common.Utils;
using Sln.Shared.Common.Values;
using Microsoft.AspNetCore.SignalR.Client;
using Sln.Shared.Common.Constants.Envs;

namespace Sln.Management.Business.Services.Realtime;
public class RealtimeServices
{
    readonly HubConnection connection;

    public RealtimeServices()
    {
        connection = new HubConnectionBuilder()
            .WithUrl(Environment.GetEnvironmentVariable(EnvConstants.PUBLISHER_REALTIME_SERVER) ?? "")
            .Build();

        connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await connection.StartAsync();
        };
    }


    public Task<int> AuthorityRefreshPageNotify(string values)
    {
        // var data = JsonSerializer.Deserialize<AuthorityRefreshPagePublishValue>(values, new JsonSerializerOptions
        // {
        //     PropertyNameCaseInsensitive = true
        // });

        // await InvokeAsync(RealtimeMethods.Update, new BaseRealtimeHubModel
        // {
        //     Key = RealTimeUtils.GetKey(RealTimeJobs.REFRESH_PAGE, $"{data!.BranchId}-{data!.ProfileId}"),
        //     Data = new
        //     {
        //         profileId = data.ProfileId
        //     }
        // });
        return Task.FromResult(1);
    }

    public async Task StartAsync()
    {
        if (connection.State == HubConnectionState.Connected)
        {
            return;
        }

        try
        {
            await connection.StartAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}]:{ex.Message}");
            throw;
        }
    }

    public async Task InvokeAsync(string methodName, object? request)
    {
        try
        {
            await StartAsync();
            await connection.InvokeAsync(methodName, request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}]:{ex.Message}");
            throw;
        }
    }

    public async Task InvokeAsync(string methodName)
    {
        try
        {
            await StartAsync();
            await connection.InvokeAsync(methodName);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")}]:{ex.Message}");
            throw;
        }
    }
}
