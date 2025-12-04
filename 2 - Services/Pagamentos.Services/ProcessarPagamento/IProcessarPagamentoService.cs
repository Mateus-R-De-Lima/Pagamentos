using Pagamentos.Shared.ModelNotication;

namespace Pagamentos.Service.ProcessarPagamento
{
    public interface IProcessarPagamentoService
    {
        Task Executa(PagamentoNotification notification);
    }
}