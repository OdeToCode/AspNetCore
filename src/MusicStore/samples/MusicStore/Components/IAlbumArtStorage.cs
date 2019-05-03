using System.IO;
using System.Threading.Tasks;

namespace MusicStore.Components
{
    public interface IAlbumArtStorage
    {
        Task<string> SaveAlbumArt(string name, Stream content);
    }
}
