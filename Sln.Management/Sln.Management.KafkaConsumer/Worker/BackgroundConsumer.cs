using Sln.Management.Business.Services.Realtime;
using Sln.Shared.Common.Interfaces;
using Sln.Shared.Common.Kafka;
using Sln.Shared.Common.Values;

public class BackgroundConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IKafkaConsumerService _kafkaConsumerService;
    private readonly RealtimeServices _realtimeServices;

    public BackgroundConsumer(IServiceProvider serviceProvider, RealtimeServices realtimeServices)
    {
        var scope = serviceProvider.CreateScope();
        _serviceProvider = serviceProvider;
        _kafkaConsumerService = scope.ServiceProvider.GetRequiredService<IKafkaConsumerService>();
        _realtimeServices = realtimeServices;
    }

    private T CreateContextService<T>() where T : class
    {
        var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {

  

        // Task.Run(async () =>
        // {
        //     await _kafkaConsumerService.SubscribeTopic(KafkaTopics.Sale_Detail_Commission_Handler.ToString(), async (KafkaMessage message) =>
        //     {
        //         var _commissionJobService = CreateContextService<CommissionJobService>();

        //         await _commissionJobService.ProcessCommission(message.Data ?? "");

        //     }, stoppingToken);
        // }, stoppingToken);

        Task.Run(async () =>
        {
            await _kafkaConsumerService.SubscribeTopic(KafkaTopics.Authority_Refresh_Page.ToString(), async (KafkaMessage message) =>
            {
                await _realtimeServices.AuthorityRefreshPageNotify(message.Data ?? "");

            }, stoppingToken);
        }, stoppingToken);

   


        return Task.CompletedTask;
    }
}