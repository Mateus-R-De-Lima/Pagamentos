using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagamentos.Communication.DTOs.Comprovante;
using Pagamentos.Service.Comprovante;

namespace Pagamentos.Emitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprovanteController : ControllerBase
    {

        [HttpPost("{idPagamento}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> PostComprovante([FromServices] IComprovanteService comprovanteService,
                                                        [FromRoute] Guid idPagamento,
                                                        [FromForm] ComprovanteRequest request)
        {
            await comprovanteService.Executa(idPagamento, request);
            return Created(string.Empty, "");
        }

        [HttpDelete("{idPagamento}")]

        public async Task<IActionResult> DeletePagamento([FromServices] IDeletarComprovanteService deletarComprovanteService,
                                                        [FromRoute] Guid idPagamento)
        {
            await deletarComprovanteService.Executa(idPagamento);
            return NoContent();
        }
    }
}
