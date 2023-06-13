using Microsoft.EntityFrameworkCore;
using PowerFitness.Data;
using PowerFitness.DataAccess.DataContext;
using PowerFitness.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
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