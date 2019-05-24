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
            var baseUri = new Uri("your URI");
            var containerName = "albumart";
            var credentials = new StorageCredentials("your account name", "your key");
            var client = new CloudBlobClient(baseUri, credentials);

            var container = client.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(fileName);
            await blob.UploadFromStreamAsync(content);

            return $"{baseUri}{containerName}/{fileName}";
        }
    }
}
