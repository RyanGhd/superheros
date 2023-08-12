using superheros.server.Model;

namespace superheros.server.Services.Queries.SuperheroQueries;

public interface IGetAllSuperherosQuery
{
    Task<IList<Superhero>> GetAsync(string traceId);
}