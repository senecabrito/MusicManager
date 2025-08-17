namespace MusicManager.Model
{
    public class Artist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public ICollection<Album> Albums { get; private set; }

        private Artist() { }

        public Artist(string name, ICollection<Album> albums)
        {
            Id = Guid.NewGuid();
            Name = name;
            Albums = albums ?? new List<Album>();
        }
    }
}