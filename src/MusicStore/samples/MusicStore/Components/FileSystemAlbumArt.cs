using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace MusicStore.Components
{
    public class FileSystemAlbumArt : IAlbumArtStorage
    {
        private readonly IHostingEnvironment environment;

        public FileSystemAlbumArt(IHostingEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task<string> SaveAlbumArt(string name, Stream content)
        {
            var filePath = Path.Combine(environment.WebRootPath, "Images", name);
            using (var writer = File.OpenWrite(filePath))
            {
                await content.CopyToAsync(writer);
                return $"~/Images/{name}";
            }                    
        }
    }
}
