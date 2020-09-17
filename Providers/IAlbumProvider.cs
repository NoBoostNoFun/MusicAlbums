using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicAlbums.Providers
{
    public interface IAlbumProvider
    {
        public Task<List<Album>> GetAlbums(string artist);
    }
}