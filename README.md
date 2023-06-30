# Caching.Learning

## by Jannick Leismann

#### **MemoryCache** - demo of **Memory Cache** 

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

### **DistributedCache.Api.A** and **DistributedCache.Api.B** - demo of **Distributed Caching** with **Redis**

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

### Lazy Cache - demo of correct implementation of **Memory Cache**

> [Video Link](https://www.youtube.com/watch?v=Q3KzZeUudsg)
>
> Techniques used : 
> 
> * **IAppCache** - interface for lazy cache
> * **GetOrAddAsync** method of **IAppCache** to get or add cache



### **DevBlogs** - Demo of **Distributed Caching** with **Redis** 
> Techniques used :
> 
> **RedisCachingService** - caching abstraction service
> 
> **ConnectionMultiplexer** - connection manager for Redis
>
> **RedisSubscriber** - background service used for pub/sub functionality of Redis



### by Remigiusz Zalewski

### by Tim Corey