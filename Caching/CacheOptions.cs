namespace MusicAlbums.Caching
{
    public class CacheOptions
    {
        public int ExpirationInMin { get; set; }

        public string LocalDbName { get; set; } = default!;

        public bool IsEnabled =>
            ExpirationInMin > 0;
    }
}
