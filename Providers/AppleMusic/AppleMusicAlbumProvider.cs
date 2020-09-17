using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MusicAlbums.Exceptions;
using MusicAlbums.Extensions;

namespace MusicAlbums.Providers.AppleMusic
{
    public class AppleMusicAlbumProvider : IAlbumProvider
    {
        private HttpClient Http { get; }

        public AppleMusicAlbumProvider(HttpClient http) =>
            Http = http;

        public async Task<List<Album>> GetAlbums(string artistName)
        {
            var response = await Http.GetAsync($"/search?attribute=artistTerm&entity=album&term={artistName}");

            ValidateResponse(response);

            var result = await response.DeserializeTo<AppleMusicSearchResult>();
            return result.Results
                .Select(s => s.ToAlbum())
                .ToList();
        }

        private static void ValidateResponse(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.ServiceUnavailable)
                throw new ServiceUnavailableException();
            response.EnsureSuccessStatusCode();
        }
    }
}