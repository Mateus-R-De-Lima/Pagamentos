using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Pagamentos.Communication.DTOs.Comprovante;
using Pagamentos.Service.Comprovante;

namespace Pagamento.Comprovante.Fuctions;

public class PagamentoComprovante
{
    private readonly ILogger<PagamentoComprovante> _logger;
    private readonly ISalvarComprovanteService _salvarComprovanteService;

    public PagamentoComprovante(ILogger<PagamentoComprovante> logger, ISalvarComprovanteService salvarComprovanteService)
    {
        _logger = logger;
        _salvarComprovanteService = salvarComprovanteService;
    }

    [Function(nameof(PagamentoComprovante))]
    public async Task Run([BlobTrigger("comprovantes/{name}", Connection = "StorageConnection")] BlobClient blobClient, string name)
    {
        var comprovanteId = await _salvarComprovanteService.Executa(new SalvarComprovanteRequest
        {
            NomeArquivo = name,
            Url = blobClient.Uri.ToString()
        });

        _logger.LogInformation("Comprovante {ComprovanteId} salvo. Blob: {Name} Url: {Url}", comprovanteId, name, blobClient.Uri);
    }
}
