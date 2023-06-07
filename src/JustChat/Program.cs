using JustChat.Data;
using JustChat.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabaseConnection")));
builder.Services.AddLazyCache();
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

await app.Services.CreateScope().ServiceProvider.InitializeSeedData();
app.MapControllers();
app.Run();