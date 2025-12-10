using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AppMillionTest.Configuration;
using Microsoft.AspNetCore.StaticFiles;

namespace AppMillionTest.Infrastructure
{
    /// <summary>
    /// Service for uploading files to Azure Blob Storage.
    /// </summary>
    public static class AzureBlobService
    {
        private static readonly FileExtensionContentTypeProvider _contentTypeProvider = new();

        /// <summary>
        /// Uploads a file to Azure Blob Storage and returns the public URL.
        /// </summary>
        /// <param name="fullFilePath">Complete path to the file to upload.</param>
        /// <returns>Public URL of the uploaded blob.</returns>
        public static async Task<string> UploadScreenshot(string fullFilePath)
        {
            var fileName = Path.GetFileName(fullFilePath);
            var connectionString = ConfigService.Instance.GetAzureStorageConnectionString();
            var containerName = ConfigService.Instance.GetAzureStorageContainerName();

            // Create blob client and upload
            var blobServiceClient = new BlobServiceClient(connectionString);
            var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = containerClient.GetBlobClient(fileName);

            // Upload with proper content type
            await using var stream = File.OpenRead(fullFilePath);
            var options = new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = GetMimeType(fullFilePath) }
            };

            await blobClient.UploadAsync(stream, options);
            return blobClient.Uri.AbsoluteUri;
        }

        /// <summary>
        /// Determines the MIME type based on file extension.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>MIME type string (defaults to "application/octet-stream" if unknown).</returns>
        private static string GetMimeType(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath));

            return _contentTypeProvider.TryGetContentType(filePath, out var mimeType) 
                ? mimeType 
                : "application/octet-stream";
        }
    }
}
