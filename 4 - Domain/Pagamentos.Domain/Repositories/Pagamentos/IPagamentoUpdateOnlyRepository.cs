using Pagamentos.Domain.Entities;
using System.Linq.Expressions;

namespace Pagamentos.Domain.Repositories.Pagamentos
{
    public interface IPagamentoUpdateOnlyRepository
    {
        void Update(Pagamento pagamentoEntity, Expression<Func<Pagamento, bool>> filter);
    }
}
