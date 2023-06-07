using Bogus;
using Tynamix.ObjectFiller;
using UniBlog.Core.Models.Entity;
using UniBlog.DataAccess.DataContext;

namespace UniBlog.Data;

public static class SeedData
{
    public static async Task InitializeSeedData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));

        if (!appDataContext.Users.Any())
        {
            var userFaker = new Faker<User>().RuleFor(selector => selector.Id, Guid.NewGuid)
                .RuleFor(selector => selector.FirstName, source => source.Person.FirstName)
                .RuleFor(selector => selector.LastName, source => source.Person.LastName)
                .RuleFor(selector => selector.Username, source => source.Person.UserName)
                .RuleFor(selector => selector.EmailAddress, source => source.Person.Email)
                .RuleFor(selector => selector.Password, new MnemonicString(1,8,10).GetValue);
            var users = userFaker.Generate(5000);
            await appDataContext.Users.AddRangeAsync(users, cts.Token);
            await appDataContext.SaveChangesAsync(cts.Token);
        }

        if (!appDataContext.Posts.Any())
        {
            var random = new Random();
            var users = appDataContext.Users.ToList();
            Guid GetRandomUserId() => users[random.Next(0, users.Count)].Id;

            var postFaker = new Faker<BlogPost>().RuleFor(selector => selector.Id, Guid.NewGuid)
                .RuleFor(selector => selector.Title, new MnemonicString(3, 5,10).GetValue)
                .RuleFor(selector => selector.Description, new MnemonicString(20, 10, 20).GetValue)
                .RuleFor(selector => selector.Content, new MnemonicString(1000).GetValue)
                .RuleFor(selector => selector.CreatedTime, () => DateTime.Now)
                .RuleFor(selector => selector.UpdatedTime, () => DateTime.Now)
                .RuleFor(selector => selector.AuthorId, GetRandomUserId);

            var posts = postFaker.Generate(10000);
            await appDataContext.AddRangeAsync(posts, cts.Token);
            await appDataContext.SaveChangesAsync(cts.Token);
        }
    }
}