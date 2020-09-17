using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyCaching.Core;
using MusicAlbums.Exceptions;
using MusicAlbums.Providers;

namespace MusicAlbums.Caching
{
    public class CachedAlbumProvider : ICachedAlbumProvider
    {
        private CacheOptions Options { get; }
        private IAlbumProvider AlbumProvider { get; }
        private IEasyCachingProvider Cache { get; }

        public CachedAlbumProvider(IAlbumProvider albumProvider, IEasyCachingProvider cache, CacheOptions options) =>
            (AlbumProvider, Cache, Options) =
            (albumProvider, cache, options);

        public async Task<List<Album>> GetAlbums(string artistName)
        {
            try
            {
                var albums = await AlbumProvider.GetAlbums(artistName);

                if (!await Cache.ExistsAsync(artistName) && albums.Any())
                    await Cache.SetAsync(artistName, albums, TimeSpan.FromMinutes(Options.ExpirationInMin));

                return albums;
            }
            catch (ServiceUnavailableException exception)
            {
                var albums = await Cache.GetAsync<List<Album>>(artistName);
                return albums.HasValue ? albums.Value : throw exception;
            }
        }
    }
}
