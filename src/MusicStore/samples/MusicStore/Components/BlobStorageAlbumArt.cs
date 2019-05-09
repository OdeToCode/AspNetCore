using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.Components
{
    public class BlobStorageAlbumArt : IAlbumArtStorage
    {
        public async Task<string> SaveAlbumArt(string fileName, Stream content)
        {
            var baseUri = new Uri("https://psmusicstore.blob.core.windows.net/");
            var containerName = "albumart";
            var crednetials = new StorageCredentials("psmusicstore", "H/7QoFnEGCVLgiYlF1sQ8j8fJcpbV9GOzlSI9XZ8IJZoP3qQo9+xqKTe2Kf/n9yQ0nh95L3bOVvDF74blNw7gQ==");
            var client = new CloudBlobClient(baseUri, crednetials);

            var container = client.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromStreamAsync(content);

            return $"{baseUri}{containerName}/{fileName}";
        }
    }
}
