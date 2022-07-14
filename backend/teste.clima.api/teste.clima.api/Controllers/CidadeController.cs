using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using teste.clima.services.Cidade;

namespace teste.clima.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase
    {
        IMediator mediator;

        public CidadeController(IMediator _medi)
        {
            mediator = _medi;
        }

        [HttpGet]
        [Route("previsao-tempo")]
        public async Task<IActionResult> Listar([FromQuery] string cidade)
        {
            var resp = await mediator.Send(new SelecionarCidadePrevisaoQuery() { NomeCidade = cidade });
            return Ok(resp);
        }
    }
}
