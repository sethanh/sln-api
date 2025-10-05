using Microsoft.AspNetCore.SignalR.Client;

namespace Sln.Publisher.Business.Services.Realtime;

public class RealtimeServices
{
    readonly HubConnection connection;

    public RealtimeServices()
    {
        connection = new HubConnectionBuilder()
            .WithUrl(Environment.GetEnvironmentVariable("PUBLISHER_REALTIME_SERVER") ?? "")
            .Build();

        connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await connection.StartAsync();
        };
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
            Console.WriteLine($"Error occurred: {ex.Message}");
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
            Console.WriteLine($"Error occurred: {ex.Message}");
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
            Console.WriteLine($"Error occurred: {ex.Message}");
            throw;
        }
    }
}
