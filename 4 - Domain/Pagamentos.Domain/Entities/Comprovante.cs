namespace Pagamentos.Domain.Entities
{
    public class Comprovante
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string PagamentoId { get; set; } = string.Empty;

        public string NomeOriginal { get; set; } = string.Empty;

        public string NomeArquivo { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public long Tamanho { get; set; }

        public string Url { get; set; } = string.Empty;

        public DateTime DataUpload { get; set; }
    }
}
