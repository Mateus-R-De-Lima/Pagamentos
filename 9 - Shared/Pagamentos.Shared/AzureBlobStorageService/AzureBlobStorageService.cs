using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace Pagamentos.Shared.AzureBlobStorageService
{
    public class AzureBlobStorageService : IAzureBlobStorageService
    {

        private readonly BlobContainerClient _containerClient;
        public AzureBlobStorageService(BlobServiceClient blobServiceClient, IOptions<AzureStorageSettings> settings)
        {
            _containerClient = blobServiceClient.GetBlobContainerClient(settings.Value.ContainerName);
        }

        public async Task<string> UploadFile(string fileName, Stream fileStream, string contentType, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(_containerClient.Uri);
            // Implementation for uploading file to Azure Blob Storage
            await _containerClient.CreateIfNotExistsAsync(
                      cancellationToken: cancellationToken);

            var blobClient = _containerClient.GetBlobClient(fileName);


            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = contentType
                }
            };

            await blobClient.UploadAsync(fileStream, options, cancellationToken);

            return blobClient.Uri.ToString();
        }


        public async Task<bool> DeleteFile(string fileName, CancellationToken cancellationToken = default)
        {
            var blobClient = _containerClient.GetBlobClient(fileName);

            await blobClient.DeleteIfExistsAsync(
                cancellationToken: cancellationToken);

            return true;
        }
    }
}