using Microsoft.Extensions.Configuration;

namespace MusicAlbums.Extensions
{
    public static class ConfigurationExtensions
    {
        public static T GetOptions<T>(this IConfiguration configuration) where T : new()
        {
            var option = new T();
            configuration.GetSection(typeof(T).Name).Bind(option);
            return option;
        }
    }
}