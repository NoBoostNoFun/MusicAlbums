using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicAlbums.Providers;

namespace MusicAlbums
{
    public class AlbumManager
    {
        private IAlbumProvider AlbumProvider { get; }

        public AlbumManager(IAlbumProvider albumProvider) =>
            AlbumProvider = albumProvider;

        public async Task<Dictionary<string, List<Album>>> GetAlbumsByArtist(string artistName)
        {
            var albums = await AlbumProvider.GetAlbums(artistName);
            return albums
                .GroupBy(g => g.Artist)
                .ToDictionary(k => k.Key, v => v.OrderBy(o => o.Date).ToList());
        }
    }
}
