using Bogus;
using JustChat.Core.Models.Entities;
using JustChat.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Tynamix.ObjectFiller;

namespace JustChat.Data;

public static class SeedData
{
    public static async Task InitializeSeedData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var cts = new CancellationTokenSource(TimeSpan.FromMinutes(5));

        if (!appDataContext.Groups.Any())
        {
            var groupChatFaker = new Faker<GroupChat>().RuleFor(selector => selector.Id, Guid.NewGuid)
                .RuleFor(selector => selector.Name, new MnemonicString(1, 8, 20).GetValue)
                .RuleFor(selector => selector.Description, new MnemonicString(10, 8, 20).GetValue)
                .RuleFor(selector => selector.CreatedDate, DateTimeOffset.Now)
                .RuleFor(selector => selector.UpdatedDate, DateTimeOffset.Now);
            var groups = groupChatFaker.Generate(5000);
            await appDataContext.Groups.AddRangeAsync(groups, cts.Token);
            await appDataContext.SaveChangesAsync(cts.Token);
        }

        if (!appDataContext.Announcements.Any())
        {
            var random = new Random();
            var groups = await appDataContext.Groups.ToListAsync(cancellationToken: cts.Token);
            Guid GetRandomGroupId() => groups[random.Next(0, groups.Count)].Id;
            var announcementFaker = new Faker<GroupAnnouncement>().RuleFor(selector => selector.Id, Guid.NewGuid)
                .RuleFor(selector => selector.Message, new MnemonicString(1, 8, 20).GetValue)
                .RuleFor(selector => selector.SentTime, DateTimeOffset.Now)
                .RuleFor(selector => selector.EditedTime, DateTimeOffset.Now)
                .RuleFor(selector => selector.GroupId, GetRandomGroupId);
            var announcements = announcementFaker.Generate(15000);
            await appDataContext.Announcements.AddRangeAsync(announcements, cts.Token);
            await appDataContext.SaveChangesAsync(cts.Token);
        }
    }
}