using AnimeFlix.Business.Entities;

namespace AnimeFlix.Business.Interfaces
{
    public interface ISessionService : IDisposable
    {
        Task<List<Session>> GetSessionsByUserAsync(Guid userId);
        Task<Session> GetSessionByAnimeIdAsync(Guid animeId);
        Task SaveSessionAsync(Session session);
    }
}
