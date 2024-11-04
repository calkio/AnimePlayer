using AnimePlayer.Core.Models;
using AnimePlayer.Core.Repositories;
using AnimePlayer.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace AnimePlayer.DataAccess.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AnimePlayerDbContex _context;

        public AnimeRepository(AnimePlayerDbContex context)
        {
            _context = context;
        }

        public async Task<List<Anime>> Get()
        {
            var animesEntites = await _context.Animes
                .AsNoTracking()
                .ToListAsync();

            var animes = animesEntites
                .Select(a => Anime.Create(a.Id, a.Title, a.Description, a.YearIssue).Anime)
                .ToList();

            return animes;
        }

        public async Task<Guid> Create(Anime anime)
        {
            var animeEntity = new AnimeEntites
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                YearIssue = anime.YearIssue,
            };

            await _context.Animes.AddAsync(animeEntity);
            await _context.SaveChangesAsync();

            return anime.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, int yearIssue)
        {
            await _context.Animes
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.Title, a => title)
                    .SetProperty(a => a.Description, a => description)
                    .SetProperty(a => a.YearIssue, a => yearIssue));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Animes
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
