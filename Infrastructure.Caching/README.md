About

The package is designed for caching data in .NET applications.

How to Use

Main Types

    ICacheService<string, string> сacheService = new MemoryCacheService<string, string>(new MemoryCache(new MemoryCacheOptions()));
    var absoluteExpiration = new DateTimeOffset(DateTime.UtcNow.AddMinutes(10));
    var key = "key1";
    var value = "value1";
    var message = string.Empty;
    
    сacheService.Set(key, value, absoluteExpiration);        //Added a value to the cache for the key.

    if (сacheService.TryGetValue(key, out var cachedValue))  //Getting the value from the cache by key.
    {
        message = $"The cached value is '{cachedValue}'";
    }
    else
    {
        message = "The key value is missing from the cache.";
    }

    Console.WriteLine(message);

    сacheService.Remove(key);                               //Deleting a value from the cache by key.

  

The main types provided by this library are:

    Infrastructure.Caching.Services.ICacheService<in TKey, TValue>
    Infrastructure.Caching.Services.MemoryCacheService<TKey, TValue>


Feedback & Contributing

Infrastructure.Caching is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.