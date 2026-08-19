using Pagamentos.Domain.Entities;
using Pagamentos.Domain.Repositories.Comprovantes;
using Pagamentos.Infrastructure.Mongo;

namespace Pagamentos.Infrastructure.DataAccess
{
    public class ComprovanteRepository(MongoContext mongoContext) : IComprovanteWriteOnlyRepository
    {
        public async Task AddAsync(Comprovante comprovante)
        {
            await mongoContext.Comprovantes.InsertOneAsync(comprovante);
        }
    }
}
