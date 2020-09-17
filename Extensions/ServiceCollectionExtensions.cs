using System;
using EasyCaching.SQLite;
using Microsoft.Extensions.DependencyInjection;
using MusicAlbums.Caching;
using MusicAlbums.Providers;
using MusicAlbums.Providers.AppleMusic;

namespace MusicAlbums.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddAppleMusicAlbumProvider(this IServiceCollection services, AppleMusicOptions options)
        {
            services.AddHttpClient<IAlbumProvider, AppleMusicAlbumProvider>(client =>
            {
                client.BaseAddress = new Uri(options.ApiUrl);
            });
            return services;
        }

        public static IServiceCollection AddCache(this IServiceCollection services, CacheOptions cacheOptions) =>
            services
                .AddEasyCaching(o => o.UseSQLite(config =>
                {
                    config.DBConfig = new SQLiteDBOptions { FileName = cacheOptions.LocalDbName };
                }))
                .AddSingleton(cacheOptions)
                .AddSingleton<ICachedAlbumProvider, CachedAlbumProvider>();

    }
}