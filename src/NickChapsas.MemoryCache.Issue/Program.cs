using LazyCache;
using Microsoft.Extensions.Caching.Memory;

// Case A - get or create with delegate
var memoryCache = new MemoryCache(new MemoryCacheOptions());
var counter = 0;

Console.WriteLine("Case A : with GetOrCreate");
Parallel.ForEach(Enumerable.Range(1, 50),
    _ =>
    {
        var cachedItem = memoryCache.GetOrCreate("keyA",
            _ =>
            {
                Interlocked.Increment(ref counter);
                Console.WriteLine($"Item just set : {counter}");
                return counter;
            });
        Console.WriteLine($"Cached item : {cachedItem}");
    });

// Case B - separate get and set
await Task.Delay(4000);
counter = 0;
Console.WriteLine("\nCase B : with separate Get and Set");
Parallel.ForEach(Enumerable.Range(1, 50),
    _ =>
    {
        var cachedItem = memoryCache.Get<int>("keyB");
        if (cachedItem == default)
        {
            Interlocked.Increment(ref counter);
            memoryCache.Set("keyB", counter);
            Console.WriteLine($"Item just set : {counter}");
        }
        else
            Console.WriteLine($"Cached item : {cachedItem}");
    });

// Case C - using lazy caching
await Task.Delay(4000);
counter = 0;
Console.WriteLine("\nCase C : using lazy cache");
var lazyCache = new CachingService(); 
Parallel.ForEach(Enumerable.Range(1, 50),
    _ =>
    {
        var cachedItem = lazyCache.GetOrAdd("keyC",
            _ =>
            {
                Interlocked.Increment(ref counter);
                Console.WriteLine($"Item just set : {counter}");
                return counter;
            });
        Console.WriteLine($"Cached item : {cachedItem}");
    });