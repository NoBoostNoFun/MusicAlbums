using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicAlbums.Caching;
using MusicAlbums.Extensions;
using MusicAlbums.Providers.AppleMusic;

namespace MusicAlbums
{
    public static class Di
    {
        private static ServiceProvider ServiceProvider { get; }

        static Di()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var services = new ServiceCollection()
                .AddAppleMusicAlbumProvider(configuration.GetOptions<AppleMusicOptions>());

            var cacheOptions = configuration.GetOptions<CacheOptions>();
            if (cacheOptions.IsEnabled)
                services
                    .AddCache(cacheOptions)
                    .AddSingleton(s => new AlbumManager(s.GetService<ICachedAlbumProvider>()));
            else
                services.AddSingleton<AlbumManager>();

            ServiceProvider = services.BuildServiceProvider();
        }

        public static T Get<T>() =>
            ServiceProvider.GetService<T>();
    }
}
