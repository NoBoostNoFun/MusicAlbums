using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicAlbums.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> DeserializeTo<T>(this HttpResponseMessage response) =>
            await JsonSerializer.DeserializeAsync<T>(
                await response.Content.ReadAsStreamAsync(),
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
    }
}