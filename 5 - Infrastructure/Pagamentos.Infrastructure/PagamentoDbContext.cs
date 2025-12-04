using Microsoft.EntityFrameworkCore;
using Pagamentos.Domain.Entities;

namespace Pagamentos.Infrastructure
{
    public class PagamentoDbContext : DbContext
    {
        public PagamentoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<PagamentoProcessado> PagamentosProcessados { get; set; }

    }
}
