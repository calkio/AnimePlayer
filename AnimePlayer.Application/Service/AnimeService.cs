using AnimePlayer.Core.Models;
using AnimePlayer.Core.Repositories;
using AnimePlayer.Core.Service;

namespace AnimePlayer.Application.Service
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;

        public AnimeService(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<IEnumerable<Anime>> GetAllAnime()
        {
            return await _animeRepository.Get();
        }

        public async Task<Guid> CreateAnime(Anime anime)
        {
            return await _animeRepository.Create(anime);
        }

        public async Task<Guid> UpdateAnime(Guid id, string title, string description, int yearIssue)
        {
            return await _animeRepository.Update(id, title, description, yearIssue);
        }

        public async Task<Guid> DeleteAnime(Guid id)
        {
            return await _animeRepository.Delete(id);
        }
    }
}
