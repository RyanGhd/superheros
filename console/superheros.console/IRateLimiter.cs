namespace superheros.console;

public interface IRateLimiter
{
    bool rateLimit(int customerId);
}