using Microsoft.AspNetCore.Mvc;
using Pagamentos.Communication.DTOs.Pagamento;
using Pagamentos.Service.Pagamento;

namespace Pagamentos.Emitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PostPagamento([FromServices] IPagamentoService pagamentoService,
                                                       [FromBody] PagamentoRequest request)
        {
            pagamentoService.Executa(request);
            return Created(string.Empty, "");
        }
    }
}
