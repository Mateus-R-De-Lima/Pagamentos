using Pagamentos.Communication.DTOs.Comprovante;
using Pagamentos.Domain.Repositories.Pagamentos;
using Pagamentos.Shared.AzureBlobStorageService;

namespace Pagamentos.Service.Comprovante
{
    public class EnviarComprovanteService(IPagamentosReadOnlyRepository pagamentosReadOnlyRepository, IAzureBlobStorageService azureBlobStorageService) : IComprovanteService
    {

        public async Task<string> Executa(Guid idPagamento, ComprovanteRequest request)
        {
            var pagamento = await pagamentosReadOnlyRepository.GetByIdAsync(idPagamento);

            if (pagamento is null)
                throw new InvalidOperationException("Pagamento não encontrado");

            if (pagamento.StatusPagamento != Domain.Enums.StatusPagamento.Pendente)
                throw new InvalidOperationException("Pagamento não está pendente");

            await ValideteComprovanteRequest(request);

            var nomeArquivo = $"{Guid.NewGuid()}{request.Arquivo.FileName}";

            var urlArquivo = await azureBlobStorageService.UploadFile(idPagamento.ToString(), request.Arquivo.OpenReadStream(), request.Arquivo.ContentType);

            if(string.IsNullOrEmpty(urlArquivo))
                throw new InvalidOperationException("Erro ao fazer upload do arquivo");

            return urlArquivo;
        }


        private async Task ValideteComprovanteRequest(ComprovanteRequest request)
        {
            if (request.Arquivo is null)
                throw new InvalidOperationException("Arquivo não enviado");

            if (request.Arquivo.Length == 0)
                throw new InvalidOperationException("Arquivo vazio");

            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };

            var fileExtension = Path.GetExtension(request.Arquivo.FileName).ToLowerInvariant();

            if (!allowedExtensions.Contains(fileExtension))
                throw new InvalidOperationException("Formato de arquivo inválido. Apenas JPG, JPEG, PNG e PDF são permitidos.");
        }
    }
}
