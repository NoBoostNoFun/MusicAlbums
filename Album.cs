using System;

namespace MusicAlbums
{
    public class Album
    {
        public string Name { get; }
        public DateTime Date { get; }
        public string Artist { get; }

        public Album(string name, DateTime date, string artist) =>
            (Name, Date, Artist) =
            (name, date, artist);

        public override string ToString() =>
            $"{Date.Year} - {Name}";
    }
}