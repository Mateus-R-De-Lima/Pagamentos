using Pagamentos.Communication.DTOs.Comprovante;

namespace Pagamentos.Service.Comprovante
{
    public interface ISalvarComprovanteService
    {
        Task<Guid> Executa(SalvarComprovanteRequest request);
    }
}
