using AnimeFlix.App.Models;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace AnimeFlix.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeService _animeService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public HomeController(IAnimeService animeService, ISessionService sessionService, IMapper mapper)
        {
            _animeService = animeService;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<AnimeViewModel> animes;

            if (User.Identity.IsAuthenticated)
            {
                var id = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                animes = _mapper.Map<IEnumerable<AnimeViewModel>>(await _animeService.GetAnimesWithSessionByUserIdAsync(id));
            }
            else
            {
                animes = _mapper.Map<IEnumerable<AnimeViewModel>>(await _animeService.GetAnimesAsync());
            }

            return View(animes);
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