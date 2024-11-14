using AnimePlayer.Core.Models;

namespace AnimePlayer.Core.Service
{
    public interface IAnimeService
    {
        Task<Guid> CreateAnime(Anime anime);
        Task<Guid> DeleteAnime(Guid id);
        Task<IEnumerable<Anime>> GetAllAnime();
        Task<Guid> UpdateAnime(Guid id, string title, string description, int yearIssue);
    }
}