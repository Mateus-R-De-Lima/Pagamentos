using Pagamentos.Domain.Entities;

namespace Pagamentos.Domain.Repositories.Pagamentos
{
    public interface IPagamentoWriteOnlyRepository
    {
        Task AddAsync(Pagamento pagamentoEntity);
    }
}
