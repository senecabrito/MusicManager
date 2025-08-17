using Microsoft.EntityFrameworkCore;
using MusicManager.Data;

namespace MusicManager
{
    public class Program
    {
        static void Main(string[] args)
        {
            using var context = new MusicManagerContext();

            // Listar todos os álbuns com artistas
            var albums = context.Albums
            .Include(a => a.Artist)
            .Include(a => a.Musics)
            .ToList();
            foreach (var album in albums)
            {
                Console.WriteLine($"Album: {album.Title}\nArtist: {album.Artist.Name}\nMusics:");
                foreach (var music in album.Musics)
                {
                    Console.WriteLine($"  - {music.Title}");
                }
                Console.WriteLine();
            }
        }
    }
}