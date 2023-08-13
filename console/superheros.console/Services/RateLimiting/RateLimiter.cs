using superheors.console.Services.RateLimiting;

namespace superheros.console.Services.RateLimiting;

public class RateLimiter : IRateLimiter
{
    private readonly RateLimitConfig _config;
    private readonly Dictionary<string, IRateQueue> _queues = new Dictionary<string, IRateQueue>();


    public RateLimiter(RateLimitConfig config)
    {
        _config = config;
    }

    public async Task<bool> IsRequestAllowedAsync(string key, long actionTimestamp)
    {
        if (_queues.TryGetValue(key, out var queue))
            return await queue.QueueAsync(actionTimestamp);

        queue = new RateQueue(key, _config);

        _queues.Add(key, queue);

        await queue.QueueAsync(actionTimestamp);

        return true;
    }
}