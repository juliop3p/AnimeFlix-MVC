using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Data.Repository
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(AnimeFlixContext db) : base(db)
        {
        }

        public async Task SaveSession(Session session)
        {
            if(session.Id == Guid.Empty)
            {
                await  Db.AddAsync(session);
                await Db.SaveChangesAsync();
            }
            else
            {
                var existingSession = await Db.Sessions.AsNoTracking().FirstOrDefaultAsync(s => s.Id == session.Id);
                existingSession.CurrentEp = session.CurrentEp;
                existingSession.CurrentTime = session.CurrentTime;

                Db.Sessions.Update(existingSession);
            }

            await Db.SaveChangesAsync();
        }
    }
}
