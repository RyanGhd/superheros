// ReSharper disable All
namespace superheros.server.Model;

public class Images
{
    // used for mapping
    private Images()
    {
        
    }
    public Images(string? xs, string? sm, string? md, string? lg)
    {
        Xs = xs;
        Sm = sm;
        Md = md;
        Lg = lg;
    }

    public string? Xs { get;private set; }
    public string? Sm { get;private set; }
    public string? Md { get;private set; }
    public string? Lg { get;private set; }
}