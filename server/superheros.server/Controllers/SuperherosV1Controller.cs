using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using superheros.server.Model;

namespace superheros.server.Controllers
{
    [ApiController]
    [Route("v1/superheros")]
    public class SuperherosV1Controller : ControllerBase
    {
        private readonly ILogger<SuperherosV1Controller> _logger;

        public SuperherosV1Controller(ILogger<SuperherosV1Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IList<object>>> GetAsync([FromHeader(Name = "x-trace-id")] string traceId)
        {
            await Task.CompletedTask;

            var response = this.StatusCode(200, new List<object>() as IList<object>);

            return response;
        }
    }
}