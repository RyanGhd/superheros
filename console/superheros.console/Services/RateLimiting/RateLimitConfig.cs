namespace superheors.console.Services.RateLimiting;

public class RateLimitConfig
{
    public TimeSpan ItemLifeTime { get; private set; }
    public long RateLimitCount { get; private set; }

    public RateLimitConfig(TimeSpan itemLifeTime, long rateLimitCount)
    {
        ItemLifeTime = itemLifeTime;
        RateLimitCount = rateLimitCount;
    }
}