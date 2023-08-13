namespace superheros.console.Services.RateLimiting;

public interface IRateQueue
{
    Task<bool> QueueAsync(long actionTimestamp);
}