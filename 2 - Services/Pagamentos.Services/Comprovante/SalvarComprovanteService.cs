using Pagamentos.Communication.DTOs.Comprovante;
using Pagamentos.Domain.Repositories.Comprovantes;

namespace Pagamentos.Service.Comprovante
{
    public class SalvarComprovanteService(IComprovanteWriteOnlyRepository comprovanteWriteOnlyRepository) : ISalvarComprovanteService
    {
        public async Task<Guid> Executa(SalvarComprovanteRequest request)
        {
            var comprovante = new Domain.Entities.Comprovante
            {
                Id = Guid.NewGuid(),
                PagamentoId = Guid.TryParse(request.NomeArquivo, out var pagamentoId)
                    ? pagamentoId.ToString()
                    : string.Empty,
                NomeArquivo = request.NomeArquivo,
                Url = request.Url,
                DataUpload = DateTime.UtcNow
            };

            await comprovanteWriteOnlyRepository.AddAsync(comprovante);

            return comprovante.Id;
        }
    }
}
