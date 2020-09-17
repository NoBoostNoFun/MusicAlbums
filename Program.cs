using System;
using System.Linq;
using System.Threading.Tasks;

namespace MusicAlbums
{
    static class Program
    {
        private static async Task Main()
        {
            try
            {
                var albumManager = Di.Get<AlbumManager>();
                await Start(albumManager);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Critical error: {exception.Message} \nPress any key to exit.");
                Console.ReadKey();
            }
        }

        private static async Task Start(AlbumManager albumManager)
        {
            while (true)
            {
                Console.WriteLine("Type an artist");
                var artistName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(artistName))
                    continue;

                var groups = await albumManager.GetAlbumsByArtist(artistName);
                if (!groups.Any())
                    Console.WriteLine("No search results");

                foreach (var (artist, albums) in groups)
                {
                    Console.WriteLine();
                    Console.WriteLine(artist);
                    albums.ForEach(Console.WriteLine);
                }

                Console.WriteLine("\nPress any key to restart or Esc to exit...");
                var keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;
                Console.Clear();
            }
        }
    }
}
