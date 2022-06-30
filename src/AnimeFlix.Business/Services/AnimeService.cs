using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Validation;

namespace AnimeFlix.Business.Services
{
    public class AnimeService : BaseService, IAnimeService
    {
        private IAnimeRepository _animeRepository;
        const string BASE_URL = "https://pitou.goyabu.com/";

        public AnimeService(IAnimeRepository animeRepository, INotificator notificator) : base(notificator)
        {
            _animeRepository = animeRepository;
        }

        public async Task<List<Anime>> GetAnimesAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public async Task<List<Anime>> GetAnimesWithSessionByUserIdAsync(Guid id)
        {
            var animesWithSession = await _animeRepository.GetAnimesWithSessionByUserIdAsync(id);
            var animes = await GetAnimesAsync();

            var allAnimes = animesWithSession.Union(animes).DistinctBy(x => x.Id).ToList();

            return allAnimes;
        }

        public async Task<Anime> GetAnimeByIdAsync(Guid id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public async Task SaveAnimeAsync(Anime anime)
        {
            var alreadyExists = await _animeRepository.FindAsync(a => a.Name.Equals(anime.Name));

            if (alreadyExists.Any())
            {
                Notify("Anime alredy exists.");
                return;
            }

            var animeUrl = BASE_URL + anime.Name.ToLower().Replace(" ", "-");

            anime.Url = animeUrl;

            if (!IsValid(new AnimeValidation(), anime))
                return;

            await _animeRepository.AddAsync(anime);
        }

        public async Task UpdateAnimeAsync(Anime anime)
        {
            var exists = await _animeRepository.FindAsync(a => a.Name.Equals(anime.Name));

            if (exists.Any())
            {
                Notify("Anime alredy exists.");
                return;
            }

            var animeUrl = BASE_URL + anime.Name.ToLower().Replace(" ", "-");

            anime.Url = animeUrl;

            if (!IsValid(new AnimeValidation(), anime))
                return;

            await _animeRepository.UpdateAsync(anime);
        }

        public async Task DeleteAnimeByIdAsync(Guid id)
        {
            await _animeRepository.DeleteByIdAsync(id);
        }

        public void Dispose()
        {
            _animeRepository?.Dispose();
        }
    }
}
