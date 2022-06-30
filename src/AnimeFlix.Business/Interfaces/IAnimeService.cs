using AnimeFlix.Business.Entities;

namespace AnimeFlix.Business.Interfaces
{
    public interface IAnimeService : IDisposable
    {
        Task<List<Anime>> GetAnimesAsync();
        Task<List<Anime>> GetAnimesWithSessionByUserIdAsync(Guid id);
        Task<Anime> GetAnimeByIdAsync(Guid id);
        Task SaveAnimeAsync(Anime anime);
        Task UpdateAnimeAsync(Anime anime);
        Task DeleteAnimeByIdAsync(Guid id);
    }
}
