using Microsoft.EntityFrameworkCore;
using MusicManager.Model.Exceptions;
using MusicManager.Data;

namespace MusicManager.Model
{
    public class MusicRepository
    {
        private readonly MusicManagerContext _context;

        public MusicRepository(MusicManagerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Music>> GetAllAsync()
        {
            return await _context.Musics
                .AsNoTracking()
                .Include(m => m.Album)
                .OrderBy(m => m.Title)
                .ToListAsync();
        }

        public async Task<Music> GetMusicByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new MusicNotFoundException("Id da música não pode ser vazio.");

            var music = await _context.Musics
                .AsNoTracking()
                .Include(m => m.Album)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (music == null)
                throw new MusicNotFoundException($"Música não encontrada.");

            return music;
        }

        public async Task AddMusicAsync(Music music)
        {
            if (music == null)
                throw new InvalidMusicException("A música fornecida é nula.");

            if (string.IsNullOrWhiteSpace(music.Title))
                throw new InvalidMusicException("A música deve ter um título válido.");

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMusicAsync(Music music)
        {
            if (music == null)
                throw new InvalidMusicException("A música fornecida é nula.");

            if (string.IsNullOrWhiteSpace(music.Title))
                throw new InvalidMusicException("A música deve ter um título válido.");

            _context.Musics.Update(music);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMusicAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new MusicNotFoundException("Id da música não pode ser vazio.");

            var music = await GetMusicByIdAsync(id);

            if (music == null)
                throw new MusicNotFoundException($"Música com Id {id} não encontrada.");

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();
        }
    }
}