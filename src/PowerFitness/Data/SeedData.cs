using Bogus;
using PowerFitness.Core.Models.Entities;
using PowerFitness.DataAccess.DataContext;
using Tynamix.ObjectFiller;

namespace PowerFitness.Data;

public static class SeedData
{
    public static async Task InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var random = new Random();

        if (!appDataContext.Users.Any())
        {
            var userFaker = new Faker<User>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Username, y => y.Person.UserName)
                .RuleFor(x => x.Password, new MnemonicString(1, 8, 20).ToString);
            var users = userFaker.Generate(1000);
            await appDataContext.Users.AddRangeAsync(users);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Subscriptions.Any())
        {
            var subscriptionFaker = new Faker<Subscription>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, new MnemonicString(1, 8, 20).ToString)
                .RuleFor(x => x.MonthlyFee, () => random.Next(20, 100));
            var subscriptions = subscriptionFaker.Generate(5);
            await appDataContext.Subscriptions.AddRangeAsync(subscriptions);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.UserSubscriptions.Any())
        {
            var users = appDataContext.Users.ToList();
            var subscriptions = appDataContext.Subscriptions.ToList();
            var userSubscriptions = users.Where(x => random.Next(0, 2) == 1)
                .Select(x => new UserSubscription
                {
                    Id = Guid.NewGuid(),
                    UserId = x.Id,
                    SubscriptionId = subscriptions[random.Next(0, subscriptions.Count)].Id,
                    SubscribedDate = DateTime.Now
                })
                .ToList();
            await appDataContext.UserSubscriptions.AddRangeAsync(userSubscriptions);
            await appDataContext.SaveChangesAsync();
        }
    }
}