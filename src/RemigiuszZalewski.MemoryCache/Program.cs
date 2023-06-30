using MemoryCache.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<DataSource>();
builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();