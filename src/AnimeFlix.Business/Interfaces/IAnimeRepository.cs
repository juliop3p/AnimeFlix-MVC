using AnimeFlix.Business.Entities;

namespace AnimeFlix.Business.Interfaces
{
    public interface IAnimeRepository : IRepository<Anime>
    {
        Task<List<Anime>> GetAnimesWithSessionByUserIdAsync(Guid id);
    }
}
