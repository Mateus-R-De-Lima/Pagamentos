using Microsoft.AspNetCore.Mvc;

namespace Pagamentos.Consumer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoProcessarController : ControllerBase
    {

        [HttpGet]

        public async Task<IActionResult> Processar()
        {
            return Ok();
        }
    }
}
