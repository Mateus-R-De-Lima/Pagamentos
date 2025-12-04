using Microsoft.EntityFrameworkCore;
using Pagamentos.Communication.DTOs.Pagamento;
using Pagamentos.Domain.Enums;
using Pagamentos.Infrastructure;
using Pagamentos.Service.Pagamento;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.RabbitMq;

namespace Pagamentos.Service.ProcessarPagamento
{
    public class ProcessarPagamentoService(PagamentoDbContext dbContext) : IProcessarPagamentoService
    {

        public async Task Executa(PagamentoNotification notification)
        {
            var pagamento = new Domain.Entities.PagamentoProcessado()
            {
                DataCriacao = notification.DataCriacao,
                Valor = notification.Valor,
                Titulo = notification.Titulo,
                DataPagamento = DateTime.UtcNow,
                StatusPagamento = StatusPagamento.Pago
            };

            await dbContext.AddAsync(pagamento);
            await dbContext.SaveChangesAsync();

            pagamento.StatusPagamento = StatusPagamento.Pago;

            dbContext.Update(pagamento);
            await dbContext.SaveChangesAsync();

        }
    }
}
