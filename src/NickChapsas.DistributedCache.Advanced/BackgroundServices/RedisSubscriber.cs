using StackExchange.Redis;

namespace NickChapsas.DistributedCache.Advanced.BackgroundServices;

public class RedisSubscriber : BackgroundService
{
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public RedisSubscriber(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        Console.WriteLine("test");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var subscriber = _connectionMultiplexer.GetSubscriber();
        return subscriber.SubscribeAsync("messages",
            (channel, value) => { Console.WriteLine($"The message content was : {value}"); });
    }
}