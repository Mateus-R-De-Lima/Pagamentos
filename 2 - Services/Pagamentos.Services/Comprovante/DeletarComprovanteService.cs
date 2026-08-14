using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Service.Pagamento;
using Pagamentos.Shared.AzureBlobStorageService;

namespace Pagamentos.Service.Comprovante
{
    public class DeletarComprovanteService(IPagamentosReadOnlyRepository pagamentosReadOnlyRepository, IAzureBlobStorageService azureBlobStorageService) : IDeletarComprovanteService
    {

        public async Task<bool> Executa(Guid idPagamento)
        {
            // Lógica para deletar o comprovante associado ao pagamento

            var pagamento = await pagamentosReadOnlyRepository.GetByIdAsync(idPagamento);
            if (pagamento is null)
                throw new InvalidOperationException("Pagamento não encontrado");

            var deletarArquivo = await azureBlobStorageService.DeleteFile(idPagamento.ToString());

            if (!deletarArquivo)
                throw new InvalidOperationException("Erro ao deletar o arquivo");

            return true;
        }
    }
}
