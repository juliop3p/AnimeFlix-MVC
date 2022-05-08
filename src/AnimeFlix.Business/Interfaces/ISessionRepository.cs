using AnimeFlix.Business.Models;

namespace AnimeFlix.Business.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<List<Session>> GetAllSessionsByUserAsync(Guid userId);
    }
}
