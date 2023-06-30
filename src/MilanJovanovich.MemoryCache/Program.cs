using MemoryCache.Data;
using MemoryCache.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<DataSource>();
builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.Decorate<IDataRepository, CachedDataRepository>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();