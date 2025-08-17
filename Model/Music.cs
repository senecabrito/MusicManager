namespace MusicManager.Model
{
    public class Music
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid AlbumId { get; private set; }
        public Album Album { get; private set; }

        private Music() { }

        public Music(string title, Album album)
        {
            Id = Guid.NewGuid();
            Title = title;
            Album = album;
            AlbumId = album.Id;
        }
    }
}