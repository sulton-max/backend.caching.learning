using LinkForwarding.Core.Data;
using LinkForwarding.Core.DataAccess.DataContexts;
using LinkForwarding.Core.DataAccess.DataRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("RedisConnection");
    // options.InstanceName = "BlinkLink";
});
builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabaseConnection")));

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.Decorate<IDataRepository, CachedDataRepository>();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

await app.Services.CreateScope().ServiceProvider.InitializeData();
app.MapControllers();

app.Run();