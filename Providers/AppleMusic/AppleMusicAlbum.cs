using System;

namespace MusicAlbums.Providers.AppleMusic
{
    [Serializable]
    public class AppleMusicAlbum
    {
        public string CollectionName { get; set; } = default!;
        public DateTime ReleaseDate { get; set; }
        public string ArtistName { get; set; } = default!;

        public Album ToAlbum() =>
            new Album(CollectionName, ReleaseDate, ArtistName);
    }
}