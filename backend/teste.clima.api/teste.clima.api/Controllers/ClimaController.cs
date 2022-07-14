using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using teste.clima.services.Clima;

namespace teste.clima.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        IMediator mediator;

        public ClimaController(IMediator _medi)
        {
            mediator = _medi;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            var resp = await mediator.Send(new ListarClimasQuery());
            return Ok(resp);
        }
    }
}
