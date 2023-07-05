# Caching.Learning

## by Jannick Leismann

### **MemoryCache** - demo of **Memory Cache** 

> [Video Link](https://www.youtube.com/watch?v=MSUTojuUEX4&)
>
> Techniques used :
> * **Get** and **Set** methods of **IMemoryCache** to get or set cache

## by Milan Jovanovich

### **MemoryCache** - demo of **Memory Cache**

> [Video Link](https://www.youtube.com/watch?v=i_3I6XLAOt0)
>
> Techniques used : 
> * **CachedDataRepository** - cached repository with **Decorator** pattern
> * **Decorate** method of scrutor to decorate registered services
> * **GetOrCreateAsync** method of **IMemoryCache** to get or create cache

### **DistributedCache.Api.A** and **DistributedCache.Api.B** - demo of **Distributed Cache** with **Redis**

> [Video Link](https://www.youtube.com/watch?v=Tt5zIKVMMbs&t=987s)
>
> **DistributedCache.Core** - Core project shared between 2 API projects
>
> Techniques used : 
> * **CachedDataRepository** - cached repository with **Decorator** pattern
> * **Decorate** method of scrutor to decorate registered services
> * **GetStringAsync** and **SetStringAsync** methods of **IDistributedCache** to get or set cache
> * **IDistributedCache** - interface for distributed cache

## by Nick Chapsas

### **LazyCache** and **MemoryCache.Issue** - demo of concurrency issue with **IMeoryCache** and solution with **LazyCache**

> [Video Link](https://www.youtube.com/watch?v=Q3KzZeUudsg)
>
> Techniques used : 
> 
> * **IAppCache** - interface for lazy cache
> * **GetOrAddAsync** method of **IAppCache** to get or add cache


### **DistributedCache.Advanced** - demo of **Distributed Cache and Pub/Sub** with **Redis** 

> [Video Link](https://www.youtube.com/watch?v=jwek4w6als4)
>
> Techniques used :
> 
> * **RedisCachingService** - caching abstraction service
> * **ConnectionMultiplexer** - connection manager for Redis
> * **RedisSubscriber** - background service used for pub/sub functionality of Redis

### **AppLevel.OutputCache** - demo of **Output Cache** 

> [Video Link](https://www.youtube.com/watch?v=0WvGwOoK-CI)
>
> Techniques used :
>
> * **OutputCache** attribute to cache action result
> * **Policy** property of **OutputCache** attribute to set cache policy
> * **AddPolicy** method of **OotputCacheOptions** when adding output cache
> * **CacheTag** - tag for cache invalidation
> * **Cache Lock** - lock for request endpoint

### **AppLevelCache.OutputCache.Redis** - demo of **Output Cache** with **Redis**

> [Video Link](https://www.youtube.com/watch?v=WeHZ_NMC-Jo)
>
> Techniques used :
>
> * **IConnectionMultiplexer** - interface for connection manager for Redis 
> * **IOutputCacheStore** - interface for output cache store
> * **RedisOutputCacheStore** - implementation of **IOutputCacheStore** for Redis
> * **OutputCacheOptions** - options for output cache
> * **AddRedisOutputCache** - extension method for adding output cache with Redis

## by Remigiusz Zalewski

### **MemoryCache** - demo of **Memory Cache**

> [Video Link](https://www.youtube.com/watch?v=iGti9y8KjGc&)
>
> Techniques used :
>
> * **IMemoryCache** - interface for memory cache
> * **GetOrCreateAsync** method of **IMemoryCache** to get or create cache

## by Tim Corey

### **DistributedCache** - demo of **Distributed Cache** with **Redis** 
> [Video Link](https://www.youtube.com/watch?v=UrQWii_kfIE)
> 
> Techniques used :
> 
> * **GetStringAsync** and **SetStringAsync** methods of **IDistributedCache** to get or set cache
> * **DistributedCacheExtensions** - extension for easy caching single object and collection of objects

## by Anton Wieslander

### **CachingStrategies** - demo of caching types and strategies

> [Video Link](https://www.youtube.com/watch?v=fb0XZTAURCo&list=PLOeFnOV9YBa77eJeW39a5Q2lsyfdxpE_d&index=1)
> [Video Link](https://www.youtube.com/watch?v=EJ73Bl3AtFY&list=PLOeFnOV9YBa77eJeW39a5Q2lsyfdxpE_d&index=2)
>
> Techniques used :
> * **NamespacedCache** - name scoped cache
> * **FallbackCache** - failure tolerant cache
> * **WriteThroughCache** - coupled data storage with cache
> * **WriteBackCache** - uses accumulated changes to update distributed cache
>
> 
> [Video Link](https://www.youtube.com/watch?v=rsXvpCHdldg&list=PLOeFnOV9YBa77eJeW39a5Q2lsyfdxpE_d&index=3)
>
> Techniques used :
> * **AddStackExchangeRedisCache** - extension method for adding Redis cache
> 