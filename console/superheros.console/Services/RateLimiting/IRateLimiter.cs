namespace superheors.console.Services.RateLimiting;

public interface IRateLimiter
{
    public Task<bool> IsRequestAllowedAsync(string key, long timestamp);

}