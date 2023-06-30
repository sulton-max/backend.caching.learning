using DevBlogs.BackgroundServices;
using DevBlogs.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection")));

builder.Services.AddSingleton<ICacheService, RedisCacheService>();
builder.Services.AddHostedService<RedisSubscriber>();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.MapControllers();
app.UseRouting();

app.Run();