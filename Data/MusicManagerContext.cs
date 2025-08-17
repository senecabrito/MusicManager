using Microsoft.EntityFrameworkCore;
using MusicManager.Model;

namespace MusicManager.Data
{
    public class MusicManagerContext : DbContext // DbContext é uma classe base do Entity Framework Core que representa uma sessão com o banco de dados
    {
        public DbSet<Album> Albums { get; set; } // DbSet representa uma coleção de entidades do tipo Album no banco de dados
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Music> Musics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Configura a string de conexão para o banco de dados SQLite
            options.UseSqlite("Data Source=MusicManager.db");
        }
    }
}