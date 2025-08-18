namespace MusicManager.Model.Exceptions
{
    public class MusicNotFoundException : Exception
    {
        public MusicNotFoundException()
            : base("Música não encontrada.") { }

        public MusicNotFoundException(string message)
            : base(message) { }

        public MusicNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}