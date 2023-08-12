using Microsoft.Extensions.Caching.Memory;

namespace superheros.server.Services.Platform;

public interface ICacheProvider
{
    Task<T> GetAsync<T>(string key);
    Task SetAsync<T>(string key, T value, TimeSpan lifetime);
}
public class CacheProvider : ICacheProvider
{
    private readonly IMemoryCache _memoryCache;

    public CacheProvider(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public Task<T?> GetAsync<T>(string key)
    {
        if (_memoryCache.TryGetValue(key, out object? value))
            return Task.FromResult<T>((T?)value);

        return Task.FromResult(default(T?));
    }

    public Task SetAsync<T>(string key, T value, TimeSpan lifetime)
    {
        _memoryCache.Set(key, value, lifetime);

        return Task.CompletedTask;
    }
}