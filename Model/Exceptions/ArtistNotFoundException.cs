namespace MusicManager.Model.Exceptions
{
    public class ArtistNotFoundException : Exception
    {
        public ArtistNotFoundException()
            : base("Artista não encontrado.") { }

        public ArtistNotFoundException(string message)
            : base(message) { }

        public ArtistNotFoundException(string message, Exception innerException)
            : base(message, innerException) {}
    }
}