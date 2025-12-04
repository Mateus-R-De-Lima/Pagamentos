using Pagamentos.Communication.DTOs.Pagamento;
using Pagamentos.Domain.Enums;
using Pagamentos.Infrastructure;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.RabbitMq;

namespace Pagamentos.Service.Pagamento
{
    public class PagamentoService(PagamentoDbContext dbContext,RabbitMqClient rabbitMq) : IPagamentoService
    {

        public async Task Executa(PagamentoRequest request)
        {
            var pagamento = new Domain.Entities.Pagamento()
            {
                Titulo = request.Titulo,
                Valor = request.Valor,               
                StatusPagamento = StatusPagamento.Processando
            };

            await dbContext.AddAsync(pagamento);
            await dbContext.SaveChangesAsync();

            var notification = new PagamentoNotification()
            {
                Id = pagamento.Id,
                DataCriacao = pagamento.DataCriacao,
                Titulo = pagamento.Titulo,
                Valor = pagamento.Valor,
            };

            rabbitMq.Publish<PagamentoNotification>(notification);

        }
    }
}
