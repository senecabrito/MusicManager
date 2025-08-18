using Microsoft.EntityFrameworkCore;
using MusicManager.Model.Exceptions;
using MusicManager.Data;

namespace MusicManager.Model
{
    public class AlbumRepository
    {
        private readonly MusicManagerContext _context;

        public AlbumRepository(MusicManagerContext context)
        {
            _context = context;
        }

        // Retorna todos os álbuns com artistas e músicas carregados
        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Musics)
                .ToListAsync();
        }

        // Retorna um álbum pelo Id, lança AlbumNotFoundException se não existir
        public async Task<Album> GetByIdAsync(Guid id)
        {
            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Musics)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (album == null)
                throw new AlbumNotFoundException();

            return album;
        }

        // Adiciona um álbum ao banco
        public async Task AddAsync(Album album)
        {
            if (album == null) throw new InvalidAlbumException("O álbum fornecido é nulo.");

            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        // Atualiza um álbum existente
        public async Task UpdateAsync(Album album)
        {
            if (album == null) throw new InvalidAlbumException("O álbum fornecido é nulo.");

            _context.Albums.Update(album);
            await _context.SaveChangesAsync();
        }

        // Remove um álbum pelo Id, lança AlbumNotFoundException se não existir
        public async Task DeleteAsync(Guid id)
        {
            var album = await GetByIdAsync(id);
            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
        }
    }
}