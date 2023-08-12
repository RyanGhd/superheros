using Microsoft.AspNetCore.Mvc;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuperheroController : ControllerBase
    {
        private readonly ILogger<SuperheroController> _logger;
        private readonly IGetAllSuperheros _getAllSuperheros;

        public SuperheroController(ILogger<SuperheroController> logger, IGetAllSuperheros getAllSuperheros)
        {
            _logger = logger;
            _getAllSuperheros = getAllSuperheros;
        }

        [HttpGet]
        public Task<ActionResult<IEnumerable<Superhero>>> GetAsync()
        {
             throw new NotImplementedException();
             
        }
    }
}