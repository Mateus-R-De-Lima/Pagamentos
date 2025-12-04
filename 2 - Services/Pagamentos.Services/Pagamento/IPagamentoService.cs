using Pagamentos.Communication.DTOs.Pagamento;

namespace Pagamentos.Service.Pagamento
{
    public interface IPagamentoService
    {
        Task Executa(PagamentoRequest request);
    }
}