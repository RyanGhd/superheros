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
        private readonly IGetAllSuperherosQuery _getAllSuperheros;
        private readonly IGetSuperheroByIdQuery _getSuperheroByIdQuery;

        public SuperherosController(ILogger<SuperherosController> logger, IGetAllSuperherosQuery getAllSuperheros, IGetSuperheroByIdQuery getSuperheroByIdQuery)
        {
            _logger = logger;
            _getAllSuperheros = getAllSuperheros;
            _getSuperheroByIdQuery = getSuperheroByIdQuery;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Superhero>>> GetAsync([FromHeader(Name = "x-trace-id")] string traceId)
        {
            var result = await _getAllSuperheros.GetAsync(traceId);

            var response = this.StatusCode(200, result as IList<Superhero>);

            return response;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetAsync([FromHeader(Name = "x-trace-id")] string traceId, [FromRoute] int id)
        {
            var result = await _getSuperheroByIdQuery.GetAsync(id, traceId);

            ObjectResult response = null;
            if (result == null)
                response = this.StatusCode(404, new { error = "Superhero does not exist!" });
            else
                response = this.StatusCode(200, result);

            return response;
        }
    }
}