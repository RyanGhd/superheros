using superheros.server.Model;

namespace superheros.server.Services.Queries.SuperheroQueries;

public class GetSuperheroByIdQuery : IGetSuperheroByIdQuery
{
    private readonly ILogger<GetSuperheroByIdQuery> _logger;
    private readonly IGetAllSuperherosQuery _getAllSuperherosQuery;
    private readonly IConfiguration _config;

    public GetSuperheroByIdQuery(ILogger<GetSuperheroByIdQuery> logger, IGetAllSuperherosQuery getAllSuperherosQuery, IConfiguration config)
    {
        _logger = logger;
        _getAllSuperherosQuery = getAllSuperherosQuery;
        _config = config;
    }
    public async Task<Superhero?> GetAsync(int id, string traceId)
    {
        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - starting");

        var data = await _getAllSuperherosQuery.GetAsync(traceId);

        var superhero = data.FirstOrDefault(x => x.Id == id);

        _logger.Log(LogLevel.Debug, traceId, $"{nameof(GetAsync)} - finished");

        return superhero;
    }
}