using AppLevelCache.OutputCache.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DataSource>();
builder.Services.AddControllers();
builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("nocache", x => x.NoCache());
    options.AddPolicy("test", x => x.SetVaryByRouteValue("id").Expire(TimeSpan.FromSeconds(120)).SetLocking(false).Tag());
});

var app = builder.Build();

app.MapControllers();
app.UseOutputCache();
app.Run();