using Microsoft.AspNetCore.OutputCaching;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace AppLevelCache.OutputCache.Redis.Caching;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddOutputCache();
        services.RemoveAll<IOutputCacheStore>();
        services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

        return services;
    }

    public static IServiceCollection AddRedisOutputCache(this IServiceCollection services, Action<OutputCacheOptions> configureOptions)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);

        services.AddOutputCache(configureOptions);
        services.RemoveAll<IOutputCacheStore>();
        services.AddSingleton<IOutputCacheStore, RedisOutputCacheStore>();

        return services;
    }
}