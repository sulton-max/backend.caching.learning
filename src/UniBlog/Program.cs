using Microsoft.EntityFrameworkCore;
using UniBlog.Data;
using UniBlog.DataAccess.DataContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabaseConnection"));
});
builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

await app.Services.CreateScope().ServiceProvider.InitializeSeedData();
app.MapControllers();

app.Run();