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


### **DistributedCache.Advanced** - Demo of **Distributed Cache and Pub/Sub** with **Redis** 

> [Video Link](https://www.youtube.com/watch?v=jwek4w6als4)
>
> Techniques used :
> 
> * **RedisCachingService** - caching abstraction service
> * **ConnectionMultiplexer** - connection manager for Redis
> * **RedisSubscriber** - background service used for pub/sub functionality of Redis

### by Remigiusz Zalewski

### **MemoryCache** - demo of **Memory Cache**

> [Video Link](https://www.youtube.com/watch?v=iGti9y8KjGc&)
>
> Techniques used :
>
> * **IMemoryCache** - interface for memory cache
> * **GetOrCreateAsync** method of **IMemoryCache** to get or create cache

### by Tim Corey

### **DistributedCache** - demo of **Distributed Cache** with **Redis** 
> [Video Link](https://www.youtube.com/watch?v=UrQWii_kfIE)
> 
> Techniques used :
> 
> * **GetStringAsync** and **SetStringAsync** methods of **IDistributedCache** to get or set cache
> * **DistributedCacheExtensions** - extension for easy caching single object and collection of objects
