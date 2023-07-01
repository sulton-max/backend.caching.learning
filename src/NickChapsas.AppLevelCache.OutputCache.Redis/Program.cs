using AppLevelCache.OutputCache.Redis.Caching;
using AppLevelCache.OutputCache.Redis.Data;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataSource>();
builder.Services.AddSingleton<IConnectionMultiplexer>(_ =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")!));
builder.Services.AddControllers();
builder.Services.AddRedisOutputCache();

var app = builder.Build();

app.MapControllers();
app.UseOutputCache();
app.Run();