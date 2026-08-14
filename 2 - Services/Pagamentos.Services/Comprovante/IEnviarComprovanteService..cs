using Pagamentos.Communication.DTOs.Comprovante;

namespace Pagamentos.Service.Comprovante
{
    public interface IComprovanteService
    {
        Task<string> Executa(Guid idPagamento, ComprovanteRequest request);
    }
}