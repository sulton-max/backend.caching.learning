using DistributedCache.Core.Data;
using DistributedCache.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DataSource>();
builder.Services.AddStackExchangeRedisCache(options => options.Configuration = builder.Configuration.GetConnectionString("RedisConnection"));
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.Decorate<IDataRepository, CachedDataRepository>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();