using AnimeFlix.App.Models;
using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AnimeController : BaseController
    {
        private readonly IAnimeService _animeService;
        private readonly IMapper _mapper;

        public AnimeController(IAnimeService animeService, IMapper mapper, INotificator notificator) : base(notificator)
        {
            _animeService = animeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<AnimeViewModel>>(await _animeService.GetAnimesAsync()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var animesViewModel = await GetAnimeByIdAsync(id);

            if (animesViewModel == null)
            {
                return NotFound();
            }

            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AnimeViewModel animeViewModel)
        {
            if (!ModelState.IsValid) return View(animeViewModel);

            var anime = _mapper.Map<Anime>(animeViewModel);

            await _animeService.SaveAnimeAsync(anime);

            if (!IsValid()) return View(animeViewModel);

            return RedirectToAction("Index");
        }

        [Route("Edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var animeViewModel = await GetAnimeByIdAsync(id);

            if (animeViewModel == null)
            {
                return NotFound();
            }

            return View(animeViewModel);
        }

        [Route("Edit/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AnimeViewModel animeViewModel)
        {
            if (id != animeViewModel.Id) return NotFound();

            var exists = await GetAnimeByIdAsync(id);

            if (exists == null)
            {
                return NotFound();
            }

            var anime = _mapper.Map<Anime>(animeViewModel);

            await _animeService.UpdateAnimeAsync(anime);

            if (!IsValid()) return View(animeViewModel);

            return RedirectToAction("Index");
        }

        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var animeViewModel = await GetAnimeByIdAsync(id);

            if (animeViewModel == null)
            {
                return NotFound();
            }

            return View(animeViewModel);
        }

        [Route("Delete/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var animeViewModel = await GetAnimeByIdAsync(id);

            if (animeViewModel == null)
            {
                return NotFound();
            }

            await _animeService.DeleteAnimeByIdAsync(id);

            TempData["Success"] = "Anime was deleted!";

            return RedirectToAction("Index");
        }

        private async Task<AnimeViewModel> GetAnimeByIdAsync(Guid id)
        {
            return _mapper.Map<AnimeViewModel>(await _animeService.GetAnimeByIdAsync(id));
        }
    }
}
