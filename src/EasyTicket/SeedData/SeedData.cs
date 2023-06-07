using Bogus;
using EasyTicket.DataAccess.DataContext;
using EasyTicket.Models.Entities;
using Tynamix.ObjectFiller;

namespace EasyTicket.SeedData;

public static class SeedData
{
    public static async ValueTask InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();

        var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromMinutes(2));

        if (!appDataContext.Users.Any())
        {
            var userFaker = new Faker<User>().RuleFor(property => property.Id, Guid.NewGuid)
                .RuleFor(property => property.Email, source => source.Person.Email)
                .RuleFor(property => property.Password, new MnemonicString(1,8, 10).GetValue)
                .RuleFor(property => property.FirstName, source => source.Person.FirstName)
                .RuleFor(property => property.LastName, source => source.Person.LastName)
                .RuleFor(property => property.Address, source => source.Address.FullAddress());

            var users = userFaker.Generate(5000);
            await appDataContext.Users.AddRangeAsync(users, cancellationTokenSource.Token);
            await appDataContext.SaveChangesAsync(cancellationTokenSource.Token);
        }

        if (!appDataContext.Tickets.Any())
        {
            var random = new Random();
            var users = appDataContext.Users.ToList();
            Guid GetRandomUserId() => users[random.Next(0, users.Count)].Id;

            var ticketFaker = new Faker<Ticket>().RuleFor(property => property.Id, Guid.NewGuid)
                .RuleFor(property => property.Location, source => source.Address.City())
                .RuleFor(property => property.Destination, source => source.Address.City())
                .RuleFor(property => property.DepartureTime, source => DateTime.Now.AddDays(-random.Next(10, 20)))
                .RuleFor(property => property.UserId, GetRandomUserId);

            var tickets = ticketFaker.Generate(10000);
            await appDataContext.Tickets.AddRangeAsync(tickets, cancellationTokenSource.Token);
            await appDataContext.SaveChangesAsync(cancellationTokenSource.Token);
        }
    }
}