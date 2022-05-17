using AnimeFlix.App.Areas.Dashboard.Models;
using AnimeFlix.Business.Interfaces;
using AnimeFlix.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Areas.Dashboard.Controllers
{
    [Route("Dashboard/Anime")]
    [Area("Dashboard")]
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;

        public AnimeController(IAnimeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost()]
        public async Task<IActionResult> Create(AnimeViewModel animeViewModel)
        {
            if(!ModelState.IsValid) return View(animeViewModel);

            var anime = _mapper.Map<Anime>(animeViewModel);

            anime.Url = $"https://pitou.goyabu.com/{anime.Name.ToLower().Replace(" ", "-")}";

            await _repository.Add(anime);

            return RedirectToAction("Index", "Index");
        }
    }
}
