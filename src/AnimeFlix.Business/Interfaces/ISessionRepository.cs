using AnimeFlix.Business.Entities;

namespace AnimeFlix.Business.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task SaveSession(Session Session);
    }
}
