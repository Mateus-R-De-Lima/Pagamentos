using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Pagamentos.Communication.DTOs.Pagamento;
using Pagamentos.Service.Pagamento;
using System.Text.Json;

namespace Pagamentos.Fuctions
{
    public class Pagamento(ILogger<Pagamento> logger, IPagamentoService pagamentoService)
    {
       
       

        [Function("Pagamento")]
        public  async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var request = await req.ReadFromJsonAsync<PagamentoRequest>();

            if (request is null)
                return new BadRequestObjectResult("Body inválido.");

            await pagamentoService.Executa(request);

            logger.LogInformation("Pagamento executado com sucesso.");
            return new OkObjectResult("Pagamento executado com sucesso.");
        }
        
    }
}
