namespace Pagamentos.Service.Comprovante
{
    public interface IDeletarComprovanteService
    {
        Task<bool> Executa(Guid idPagamento);
    }
}