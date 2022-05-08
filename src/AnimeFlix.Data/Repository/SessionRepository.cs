using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Models;
using AnimeFlix.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Data.Repository
{
    public class SessionRepository : Repository<Session>, ISessionRepository
    {
        public SessionRepository(AnimeFlixContext db) : base(db)
        {
        }

        public async Task<List<Session>> GetAllSessionsByUserAsync(Guid userId)
        {
            return await Db.Sessions.AsNoTracking()
                .Where(s => s.UserId == userId)
                .Include(a => a.Anime)
                .ToListAsync();
        }
    }
}
