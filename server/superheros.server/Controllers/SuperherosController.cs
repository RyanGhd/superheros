using Microsoft.AspNetCore.Mvc;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.Controllers
{
    [ApiController]
    [Route("superheros")]
    public class SuperherosController : ControllerBase
    {
        private readonly ILogger<SuperherosController> _logger;
        private readonly IGetAllSuperheros _getAllSuperheros;

        public SuperherosController(ILogger<SuperherosController> logger, IGetAllSuperheros getAllSuperheros)
        {
            _logger = logger;
            _getAllSuperheros = getAllSuperheros;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Superhero>>> GetAsync()
        {
            var result = await _getAllSuperheros.GetAsync(this.HttpContext.TraceIdentifier);

            var response = this.StatusCode(200,result as IList<Superhero>);

            return response;
        }
    }
}