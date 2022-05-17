using AnimeFlix.App.Areas.Dashboard.Models;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Areas.Player.Controllers
{
    [Area("Player")]
    public class PlayerController : Controller
    {
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;

        public PlayerController(IAnimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [Route("{id:guid}")]
        public async Task<IActionResult> Index(Guid id)
        {
            var anime = await _repository.GetById(id);

            var animeViewModel = _mapper.Map<AnimeViewModel>(anime);

            animeViewModel.Url = animeViewModel.Url + "/01.mp4";

            return View(animeViewModel);
        }
    }
}
