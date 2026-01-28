using Pagamentos.Domain.Entities;

namespace Pagamentos.Domain.Repositories.Pagamentos
{
    public interface IPagamentosReadOnlyRepository
    {
        Task<Pagamento?> GetByIdAsync(Guid id);
    }
}
