namespace MusicAlbums.Exceptions
{
    public class ServiceUnavailableException : MusicAlbumsException
    {
        public ServiceUnavailableException() : base("Server is unavailable at this moment.") { }
    }
}