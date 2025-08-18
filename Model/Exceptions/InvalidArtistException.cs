namespace MusicManager.Model.Exceptions
{
    public class InvalidArtistException : Exception
    {
        public InvalidArtistException()
            : base("Artista inválido.") { }

        public InvalidArtistException(string message)
            : base(message) { }

        public InvalidArtistException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}