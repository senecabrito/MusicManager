using Microsoft.EntityFrameworkCore;
using MusicManager.Model.Exceptions;
using MusicManager.Data;

namespace MusicManager.Model
{
    public class ArtistRepository
    {
        private readonly MusicManagerContext _context;

        public ArtistRepository(MusicManagerContext context)
        {
            _context = context;
        }

        // Busca por ID rastreado, adequado para leitura ou futuras atualizações
        public async Task<Artist> GetArtistByIdAsync(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
                throw new ArtistNotFoundException("Artista não encontrado.");

            return artist;
        }


        // Retorna todos artistas sem rastreamento
        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _context.Artists
                .AsNoTracking() // AsNoKTracking para consultas leves
                .OrderBy(a => a.Name) // Ordena por nome
                .ToListAsync();
        }

        public async Task AddArtistAsync(Artist artist)
        {
            if (artist == null)
                throw new InvalidArtistException("O artista fornecido é nulo.");

            if (string.IsNullOrWhiteSpace(artist.Name))
                throw new InvalidArtistException("O artista deve ter um nome válido.");

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            if (artist == null)
                throw new InvalidArtistException("O artista fornecido é nulo.");

            if (string.IsNullOrWhiteSpace(artist.Name))
                throw new InvalidArtistException("O artista deve ter um nome válido.");

            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
                throw new ArtistNotFoundException("Artista não encontrado.");

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
        }
    }
}