using Pagamentos.Domain.Entities;

namespace Pagamentos.Domain.Repositories.Comprovantes
{
    public interface IComprovanteWriteOnlyRepository
    {
        Task AddAsync(Comprovante comprovante);
    }
}
