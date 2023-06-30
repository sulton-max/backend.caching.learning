using DistributedCache.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    options.InstanceName = "TimCorey.DistributedCache";
});
builder.Services.AddSingleton<DataSource>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();