using AnimeFlix.App.Areas.Dashboard.Models;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class IndexController : Controller
    {
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;

        public IndexController(IAnimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var animes = await _repository.GetAll();

            var animesViewModel = _mapper.Map<IEnumerable<AnimeViewModel>>(animes);

            return View(animesViewModel);
        }
    }
}
