namespace MusicManager.Exceptions
{
    public class AlbumNotFoundException : Exception
    {
        public AlbumNotFoundException()
            : base("Álbum não encontrado.") { }

        public AlbumNotFoundException(string message)
            : base(message) { }
            
        public AlbumNotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}