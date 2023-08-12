using System.Collections.Immutable;
using Newtonsoft.Json;
using superheros.server.Model;

namespace superheros.server.Services.Queries.SuperheroQueries;

public interface IGetAllSuperheros
{
    Task<IList<Superhero>> GetAsync(string traceId);
}

public class GetAllSuperheros : IGetAllSuperheros
{
    private readonly ILogger<GetAllSuperheros> _logger;

    public GetAllSuperheros(ILogger<GetAllSuperheros> logger)
    {
        _logger = logger;
    }
    public async Task<IList<Superhero>> GetAsync(string traceId)
    {
        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - starting");

        var dataString = await File.ReadAllTextAsync(Path.Combine("Data", "superheros.json"));

        var superheros = JsonConvert.DeserializeObject<List<Superhero>>(dataString);

        var result = ImmutableList<Superhero>.Empty;

        if (superheros != null)
            result = result.AddRange(superheros);

        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - finished");

        return result;
    }
}