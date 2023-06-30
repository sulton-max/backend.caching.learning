using Bogus;
using FastCloud.Core.Models.Entities;
using FastCloud.DataAccess.DataContexts;
using Microsoft.EntityFrameworkCore;
using Tynamix.ObjectFiller;

namespace FastCloud.Data;

public static class SeedData
{
    public static async Task InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var random = new Random();

        if (!appDataContext.Users.Any())
        {
            var userFaker = new Faker<User>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.EmailAddress, y => y.Person.Email)
                .RuleFor(x => x.Password, () => new MnemonicString(1, 8, 20).ToString())
                .RuleFor(x => x.UserName, y => y.Person.UserName);
            var users = userFaker.Generate(1000);
            await appDataContext.Users.AddRangeAsync(users);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Servers.Any())
        {
            var users = await appDataContext.Users.ToListAsync();
            var serverFaker = new Faker<CloudServer>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, () => new MnemonicString(1, 8, 20).ToString())
                .RuleFor(x => x.OwnerId, () => users[random.Next(0, users.Count)].Id);

            var servers = serverFaker.Generate(1000);
            await appDataContext.Servers.AddRangeAsync(servers);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Services.Any())
        {
            var serviceFaker = new Faker<CloudService>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, () => new MnemonicString(1, 8, 20).ToString())
                .RuleFor(x => x.IsBackground, () => random.Next(0, 2) == 1);

            var services = serviceFaker.Generate(20);
            await appDataContext.Services.AddRangeAsync(services);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.ServerServices.Any())
        {
            var servers = await appDataContext.Servers.ToListAsync();
            var services = await appDataContext.Services.ToListAsync();

            var serverServiceFaker = new Faker<ServerService>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.ServerId, () => servers[random.Next(0, servers.Count)].Id)
                .RuleFor(x => x.ServiceId, () => services[random.Next(0, services.Count)].Id);

            var serverServices = serverServiceFaker.Generate(1000);
            await appDataContext.ServerServices.AddRangeAsync(serverServices);
            await appDataContext.SaveChangesAsync();
        }
    }
}