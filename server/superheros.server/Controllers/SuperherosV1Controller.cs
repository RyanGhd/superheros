using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using superheros.server.Model;
using superheros.server.Services.Queries.SuperheroQueries;

namespace superheros.server.Controllers
{
    [ApiController]
    [Route("v1/superheros")]
    public class SuperherosV1Controller : ControllerBase
    {
        private readonly ILogger<SuperherosV1Controller> _logger;
        private readonly IGetAllSuperherosQuery _getAllSuperheros;
        private readonly IGetSuperheroByIdQuery _getSuperheroByIdQuery;

        public SuperherosV1Controller(ILogger<SuperherosV1Controller> logger, IGetAllSuperherosQuery getAllSuperheros, IGetSuperheroByIdQuery getSuperheroByIdQuery)
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

        [HttpPost()]
        public async Task<ActionResult<Superhero>> PostAsync([FromHeader(Name = "x-trace-id")] string traceId, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] Superhero superhero)
        {
            await Task.CompletedTask;

            return this.StatusCode(200);
        }
    }
}