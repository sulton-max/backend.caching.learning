using Bogus;
using LinkForwarding.Core.Core.Models.Entities;
using LinkForwarding.Core.DataAccess.DataContexts;
using Microsoft.Extensions.DependencyInjection;

namespace LinkForwarding.Core.Data;

public static class SeedData
{
    public static async Task InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var random = new Random();

        if (!appDataContext.LinkPolicies.Any())
        {
            var linkPolicyFaker = new Faker<LinkPolicy>().RuleFor(x => x.IsShareable, () => random.Next(0, 2) == 1)
                .RuleFor(x => x.ExpireTime, () => TimeSpan.FromMinutes(random.Next(1, 10)));
            var linkPolicies = linkPolicyFaker.Generate(10);
            await appDataContext.LinkPolicies.AddRangeAsync(linkPolicies);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Links.Any())
        {
            var linkPolicies = appDataContext.LinkPolicies.ToList();
            var linkFaker = new Faker<Link>().RuleFor(x => x.Name, y => y.Company.CompanyName())
                .RuleFor(x => x.ShortenedLink, y => y.Internet.Url())
                .RuleFor(x => x.ActualLink, y => y.Internet.Url())
                .RuleFor(x => x.PolicyId, () => linkPolicies[random.Next(0, linkPolicies.Count)].Id);
            var links = linkFaker.Generate(1000);
            await appDataContext.Links.AddRangeAsync(links);
            await appDataContext.SaveChangesAsync();
        }
    }
}