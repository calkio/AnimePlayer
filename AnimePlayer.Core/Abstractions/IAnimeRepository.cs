using AnimePlayer.Core.Models;

namespace AnimePlayer.Core.Repositories
{
    public interface IAnimeRepository
    {
        Task<Guid> Create(Anime anime);
        Task<Guid> Delete(Guid id);
        Task<IEnumerable<Anime>> Get();
        Task<Guid> Update(Guid id, string title, string description, int yearIssue);
    }
}