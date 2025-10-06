using Sln.Shared.Common.Interfaces;
namespace Sln.Scheduler.Host.Worker;

public class BackgroundConsumer : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IKafkaConsumerService _kafkaConsumerService;

    public BackgroundConsumer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        var scope = serviceProvider.CreateScope();
        _kafkaConsumerService = scope.ServiceProvider.GetRequiredService<IKafkaConsumerService>();
    }

    private T CreateContextService<T>() where T : class
    {
        var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetRequiredService<T>();
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
        return Task.CompletedTask;
    }

}
