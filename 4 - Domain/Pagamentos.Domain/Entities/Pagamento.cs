namespace Pagamentos.Domain.Entities
{
    public class Pagamento
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}
