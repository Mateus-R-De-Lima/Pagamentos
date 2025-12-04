using Pagamentos.Domain.Enums;

namespace Pagamentos.Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Titulo { get; set; } = string.Empty;
        public double Valor { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;       
        public StatusPagamento StatusPagamento { get; set; }
    }
}
