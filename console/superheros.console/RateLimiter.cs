using System;

namespace superheros.console;

public class RateLimiter : IRateLimiter
{
    private readonly RateLimitConfig _config;
    private readonly Dictionary<int, IRateQueue> _queues;

    public RateLimiter(RateLimitConfig config)
    {
        _config = config;
        _queues = new Dictionary<int, IRateQueue>();
    }

    public bool rateLimit(int customerId)
    {
        if (_queues.TryGetValue(customerId, out var queue))
            return queue.RateLimit();

        queue = new RateQueue(_config, customerId);

        _queues.Add(customerId,queue);

        return queue.RateLimit();
    }
}

