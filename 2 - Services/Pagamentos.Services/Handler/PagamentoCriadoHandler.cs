using Pagamentos.Service.ProcessarPagamento;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.NotificationHandler;

namespace Pagamentos.Service.Handler
{
    public class PagamentoCriadoHandler(IProcessarPagamentoService processarPagamentoService) : INotificationHandler<PagamentoNotification>
    {
        public async Task HandleAsync(PagamentoNotification notification)
        {
            await processarPagamentoService.Executa(notification);            
        }
    }
}
