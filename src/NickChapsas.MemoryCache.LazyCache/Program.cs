using MemoryCache.LazyCache.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLazyCache();
builder.Services.AddSingleton<DataSource>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();