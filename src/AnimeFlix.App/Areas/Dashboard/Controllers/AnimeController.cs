using AnimeFlix.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimeFlix.App.Areas.Dashboard.Controllers
{
    [Route("Dashboard/Anime")]
    [Area("Dashboard")]
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository _repository;

        public AnimeController(IAnimeRepository repository)
        {
            _repository = repository;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Create()
        {
            return View();
        }
    }
}
