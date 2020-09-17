using System;
using System.Collections.Generic;

namespace MusicAlbums.Providers.AppleMusic
{
    [Serializable]
    public class AppleMusicSearchResult
    {
        public List<AppleMusicAlbum> Results { get; set; } = default!;
    }
}