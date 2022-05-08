using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Models;
using AnimeFlix.Data.Context;

namespace AnimeFlix.Data.Repository
{
    public class AnimeRepository : Repository<Anime>, IAnimeRepository
    {
        public AnimeRepository(AnimeFlixContext db) : base(db)
        {
        }
    }
}
