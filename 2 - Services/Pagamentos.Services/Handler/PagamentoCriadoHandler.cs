using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.NotificationHandler;

namespace Pagamentos.Service.Handler
{
    public class PagamentoCriadoHandler : INotificationHandler<PagamentoNotification>
    {
        public Task HandleAsync(PagamentoNotification notification)
        {
            var teste = notification;

            return Task.CompletedTask;
        }
    }
}
