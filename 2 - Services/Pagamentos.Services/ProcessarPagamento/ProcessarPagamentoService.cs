using Pagamentos.Domain.Enums;
using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Shared.ModelNotication;
using System.Linq.Expressions;

namespace Pagamentos.Service.ProcessarPagamento
{
    public class ProcessarPagamentoService(IPagamentosReadOnlyRepository readOnlyRepository,
                                           IPagamentoUpdateOnlyRepository pagamentoUpdateOnlyRepository) : IProcessarPagamentoService
    {

        public async Task Executa(PagamentoNotification notification)
        {
            var pagamento = await readOnlyRepository.GetByIdAsync(notification.Id);

            if (pagamento is null)
            {
                //TODO: Incluir validações e logs
                return;
            }

            pagamento.StatusPagamento = StatusPagamento.Pago;
            pagamento.DataPagamento = DateTime.UtcNow;

            Expression<Func<Domain.Entities.Pagamento, bool>> filter = p => p.Id == pagamento.Id;

            pagamentoUpdateOnlyRepository.Update(pagamento, filter);

        }
    }
}
