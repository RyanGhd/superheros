using superheors.console.Services.RateLimiting;

namespace superheros.console.Services.RateLimiting;

public class RateQueue : IRateQueue
{
    private readonly string _key;
    private readonly RateLimitConfig _config;
    private readonly TimeSpan _iterationTimeMilliSeconds = TimeSpan.FromMilliseconds(1000);
    private readonly Queue<long> _queue;

    public RateQueue(string key, RateLimitConfig config)
    {
        _key = key;
        _config = config;
        _queue = new Queue<long>();
    }

    public Task<bool> QueueAsync(long actionTimestamp)
    {
        if (_queue.Count < this._config.RateLimitCount)
        {
            _queue.Enqueue(actionTimestamp);
            return Task.FromResult(true);
        }

        var starTime = DateTime.Now.Subtract(_config.ItemLifeTime);

        var firstItem = _queue.Peek();

        if (firstItem < starTime.Ticks)
        {
            _queue.Dequeue();
            _queue.Enqueue(actionTimestamp);
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}