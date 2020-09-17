using System;

namespace MusicAlbums.Exceptions
{
    public class MusicAlbumsException : Exception
    {
        protected MusicAlbumsException(string message) : base(message) { }
    }
}