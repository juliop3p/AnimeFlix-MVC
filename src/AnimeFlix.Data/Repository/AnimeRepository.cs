using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Data.Repository
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        public AnimeRepository(AnimeFlixContext db) : base(db)
        {
        }

        public async Task<List<Anime>> GetAnimesWithSessionByUserIdAsync(Guid id)
        {
            return await Db.Animes.AsNoTracking()
                .Include(session => session.Session)
                .Where(session => session.Session.UserId.Equals(id))
                .ToListAsync();
        }
    }
}
