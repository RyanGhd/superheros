using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using superheros.server.Model;
using superheros.server.Services.Platform;

namespace superheros.server.Services.Queries.SuperheroQueries;

public class GetAllSuperherosQuery : IGetAllSuperherosQuery
{
    private const string CacheKey = "Data";

    private readonly ILogger<GetAllSuperherosQuery> _logger;
    private readonly ICacheProvider _cacheProvider;

    public GetAllSuperherosQuery(ILogger<GetAllSuperherosQuery> logger, ICacheProvider cacheProvider)
    {
        _logger = logger;
        _cacheProvider = cacheProvider;
    }
    public async Task<IList<Superhero>> GetAsync(string traceId)
    {

        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - starting");

        var cachedData = await _cacheProvider.GetAsync<ImmutableList<Superhero>>(CacheKey);
        if (cachedData != null)
        {
            _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - loaded from cache");
            return cachedData;
        }

        var dataString = await File.ReadAllTextAsync(Path.Combine("Data", "superheros.json"));

        var superheros = JsonConvert.DeserializeObject<List<Superhero>>(dataString);

        var result = ImmutableList<Superhero>.Empty;

        if (superheros != null)
        {
            result = result.AddRange(superheros);
            await _cacheProvider.SetAsync(CacheKey, result, TimeSpan.FromHours(1));
        }

        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - finished");

        return result;
    }
}