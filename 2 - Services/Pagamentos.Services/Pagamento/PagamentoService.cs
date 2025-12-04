using Pagamentos.Communication.DTOs.Pagamento;
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
            };

            await dbContext.AddAsync(pagamento);
            await dbContext.SaveChangesAsync();

            var notification = new PagamentoNotification()
            {
                Id = pagamento.Id,
                DataCriacao = pagamento.DataCriacao,
            };

            rabbitMq.Publish<PagamentoNotification>(notification);

        }
    }
}
