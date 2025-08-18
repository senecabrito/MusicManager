namespace MusicManager.Model.Exceptions
{
    public class InvalidMusicException : Exception
    {
        public InvalidMusicException()
            : base("Música inválida.") { }

        public InvalidMusicException(string message)
            : base(message) { }

        public InvalidMusicException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}