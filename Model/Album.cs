namespace MusicManager.Model
{
    public class Album
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public Guid ArtistId { get; private set; }
        public Artist Artist { get; private set; }
        public ICollection<Music> Musics { get; private set; } = new List<Music>();
        
        private Album() { } // Construtor privado para EF Core

        public Album(string title, DateTime releaseDate, Artist artist)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReleaseDate = releaseDate;
            Artist = artist;
            ArtistId = artist.Id;
        }
    }
}