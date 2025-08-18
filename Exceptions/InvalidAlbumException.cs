namespace MusicManager.Exceptions
{
    public class InvalidAlbumException : Exception
    {
        public InvalidAlbumException() 
            : base("Álbum inválido.") { }

        public InvalidAlbumException(string message) 
            : base(message) { }

        public InvalidAlbumException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
