using superheros.server.Model;

namespace superheros.server.Services.Queries.SuperheroQueries;

public interface IGetAllSuperheros
{
    Task<IList<Superhero>> GetAsync();
}

public class GetAllSuperheros : IGetAllSuperheros
{
    public Task<IList<Superhero>> GetAsync()
    {
        throw new NotImplementedException();
    }
}