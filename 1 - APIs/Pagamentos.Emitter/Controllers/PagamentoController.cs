using Microsoft.AspNetCore.Mvc;

namespace Pagamentos.Emitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PostPagamento()
        {

            return Created(string.Empty,"");
        }
    }
}
