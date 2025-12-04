namespace Pagamentos.Shared.ModelNotication
{
    public class PagamentoNotification 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public double Valor { get; set; }
        public string Titulo { get; set; }
    }
}
