using superheros.console.Services.RateLimiting;

namespace superheors.console.Services.RateLimiting;

public class RateQueueWithTimer : IRateQueue
{
    private readonly string _key;
    private readonly RateLimitConfig _config;
    private readonly Timer _timer;
    private readonly TimeSpan _iterationTimeMilliSeconds = TimeSpan.FromMilliseconds(1000);
    private readonly Queue<long> _queue;

    public RateQueueWithTimer(string key, RateLimitConfig config)
    {
        _key = key;
        _config = config;
        _queue = new Queue<long>();
        _timer = new Timer(TimerCallback, _queue, TimeSpan.FromMilliseconds(0), _iterationTimeMilliSeconds);
    }

    public Task<bool> QueueAsync(long actionTimestamp)
    {
        if (_queue.Count >= _config.RateLimitCount)
            return Task.FromResult(false);

        _queue.Enqueue(actionTimestamp);

        return Task.FromResult(true);
    }

    private void TimerCallback(object? state)
    {
        var queue = (Queue<long>)state!;

        var startTime = DateTime.Now.Subtract(_config.ItemLifeTime);

        var shouldContinue = false;
        do
        {
            if (queue.Count == 0)
                return;

            var value = queue.Peek();
            if (value < startTime.Ticks)
            {
                queue.Dequeue();
                shouldContinue = true;
            }
            else
                shouldContinue = false;

        } while (shouldContinue);
    }
}