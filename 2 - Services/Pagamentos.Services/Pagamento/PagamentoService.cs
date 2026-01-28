using Pagamentos.Communication.DTOs.Pagamento;
using Pagamentos.Domain.Enums;
using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Infrastructure;
using Pagamentos.Infrastructure.DataAccess;
using Pagamentos.Shared.ModelNotication;
using Pagamentos.Shared.RabbitMq;

namespace Pagamentos.Service.Pagamento
{
    public class PagamentoService(IPagamentoWriteOnlyRepository pagamentoWriteOnlyRepository, RabbitMqClient rabbitMq) : IPagamentoService
    {

        public async Task Executa(PagamentoRequest request)
        {
            var pagamento = new Domain.Entities.Pagamento()
            {               
                Titulo = request.Titulo,
                Valor = request.Valor,               
                StatusPagamento = StatusPagamento.Processando
            };

            await pagamentoWriteOnlyRepository.AddAsync(pagamento);           

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
