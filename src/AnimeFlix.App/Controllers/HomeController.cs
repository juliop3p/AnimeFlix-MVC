using AnimeFlix.App.Areas.Dashboard.Models;
using AnimeFlix.App.Models;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AnimeFlix.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimeRepository _repository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IAnimeRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var animes = await _repository.GetAll();

            var animesViewModel = _mapper.Map<IEnumerable<AnimeViewModel>>(animes);

            return View(animesViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}