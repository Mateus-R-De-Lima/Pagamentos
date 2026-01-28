using MongoDB.Driver;
using Pagamentos.Domain.Entities;
using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Infrastructure.Mongo;
using System.Linq.Expressions;

namespace Pagamentos.Infrastructure.DataAccess
{
    public class PagamentoRepository(MongoContext mongoContext) : IPagamentosReadOnlyRepository, IPagamentoUpdateOnlyRepository, IPagamentoWriteOnlyRepository
    {
        public async Task AddAsync(Pagamento pagamentoEntity)
        {
            await mongoContext.Pagamentos.InsertOneAsync(pagamentoEntity);
        }

        public async Task<Pagamento?> GetByIdAsync(Guid id)
        {
            return await mongoContext.Pagamentos.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Pagamento pagamentoEntity, Expression<Func<Pagamento, bool>> filter)
        {
             mongoContext.Pagamentos.ReplaceOneAsync(filter, pagamentoEntity);
        }
    }
}
