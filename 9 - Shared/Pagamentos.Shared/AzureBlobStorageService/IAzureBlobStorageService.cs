namespace Pagamentos.Shared.AzureBlobStorageService
{
    public interface IAzureBlobStorageService
    {
        Task<bool> DeleteFile(string fileName, CancellationToken cancellationToken = default);
        Task<string> UploadFile(string fileName, Stream fileStream, string contentType, CancellationToken cancellationToken = default);
    }
}