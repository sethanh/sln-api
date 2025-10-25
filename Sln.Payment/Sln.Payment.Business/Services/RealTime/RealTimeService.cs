using Microsoft.AspNetCore.SignalR.Client;
using Sln.Payment.Data.Entities;
using Sln.Shared.Common.Constants.Envs;
using Sln.Shared.Common.Constants.Realtimes;
using Sln.Shared.Common.Utils;
using Sln.Shared.Contract.Models;

namespace Sln.Payment.Business.Services.RealTime
{
    public class RealTimeService
    {
        readonly HubConnection connection;

        public RealTimeService()
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


        public async Task ChatMessageRefresh(ChatMessage chatMessage)
        {
            await InvokeAsync(RealtimeMethods.Update, new BaseRealtimeHubModel
            {
                Key = RealTimeUtils.GetKey(RealTimeJobs.MESSAGE_REFRESH, $"{chatMessage.ConversationId}"),
                Data = new
                {
                    MessageId = chatMessage.Id,
                    Message = chatMessage.Message,
                    AccountId = chatMessage.AccountId,
                    CreationTime = chatMessage.CreationTime
                }
            });
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
}