using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Validation;

namespace AnimeFlix.Business.Services
{
    public class SessionService : BaseService, ISessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository, INotificator notificator) : base(notificator)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> GetSessionsByUserAsync(Guid userId)
        {
            var sessions = await _sessionRepository.FindAsync(session => session.Id == userId);

            return sessions.ToList();
        }

        public async Task<Session> GetSessionByAnimeIdAsync(Guid animeId)
        {
            var session = await _sessionRepository.FindAsync(session => session.AnimeId == animeId);

            return session.FirstOrDefault();
        }

        public async Task SaveSessionAsync(Session session)
        {
            if (!IsValid(new SessionValidation(), session)) 
                return;

            await _sessionRepository.SaveSession(session);
        }

        public void Dispose()
        {
            _sessionRepository?.Dispose();
        }
    }
}
