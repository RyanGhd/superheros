namespace superheros.console;

public class RateLimitConfig
{
    public int RateLimit { get; private set; }
    public TimeSpan Duration { get; private set; }

    public RateLimitConfig(int rateLimit,TimeSpan duration)
    {
        RateLimit = rateLimit;
        Duration = duration;
    }
}