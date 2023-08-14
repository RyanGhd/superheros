namespace superheros.console;

public interface IRateQueue
{
    bool RateLimit();
}

public class RateQueue: IRateQueue
{
    private readonly RateLimitConfig _config;
    private readonly int _customerId;
    private readonly Queue<long> _queue;

    public RateQueue(RateLimitConfig config, int customerId)
    {
        _config = config;
        _customerId = customerId;
        _queue = new Queue<long>();
    }

    public bool RateLimit()
    {
        if (_queue.Count < _config.RateLimit)
        {
            var ts = DateTime.Now.Ticks;
            _queue.Enqueue(ts);
            return true;
        }

        var first = _queue.Peek();

        var now = DateTime.Now;

        var start = now.Subtract(_config.Duration);

        if (first < start.Ticks)
        {
            _queue.Dequeue();
            _queue.Enqueue(now.Ticks);
            return true;
        }

        return false;
    }
}