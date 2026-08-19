namespace Pagamentos.Communication.DTOs.Comprovante
{
    public class SalvarComprovanteRequest
    {
        public string NomeArquivo { get; set; } = string.Empty;

        public string Url { get; set; } = string.Empty;
    }
}
