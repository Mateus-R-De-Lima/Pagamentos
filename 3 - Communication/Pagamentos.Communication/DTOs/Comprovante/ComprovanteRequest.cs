using Microsoft.AspNetCore.Http;

namespace Pagamentos.Communication.DTOs.Comprovante
{
    public class ComprovanteRequest
    {
        public IFormFile Arquivo { get; set; } = null!;
    }
}
