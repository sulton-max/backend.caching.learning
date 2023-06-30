using NickChapsas.DistributedCache.Advanced.BackgroundServices;
using NickChapsas.DistributedCache.Advanced.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")!));
builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddHostedService<RedisSubscriber>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.UseRouting();
app.Run();