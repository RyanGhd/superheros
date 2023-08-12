using superheros.server.Model;

namespace superheros.server.Services.Queries.SuperheroQueries;

public interface IGetSuperheroByIdQuery
{
    Task<Superhero?> GetAsync(int id, string traceId);
}