using AnimeFlix.App.Models;
using AnimeFlix.Business.Entities;
using AnimeFlix.Business.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimeFlix.App.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IAnimeService _animeService;
        private readonly ISessionService _sessionService;
        private readonly IMapper _mapper;

        public PlayerController(IAnimeService animeService, ISessionService sessionService, IMapper mapper)
        {
            _animeService = animeService;
            _sessionService = sessionService;
            _mapper = mapper;
        }

        [Route("Watch/{id:guid}")]
        public async Task<IActionResult> Index(Guid id)
        {
            var anime = _mapper.Map<AnimeViewModel>(await _animeService.GetAnimeByIdAsync(id));

            if(User.Identity.IsAuthenticated)
            {
                var session = _mapper.Map<SessionViewModel>(await _sessionService.GetSessionByAnimeIdAsync(id));

                if(session == null)
                    session = new SessionViewModel();

                anime.Session = session;
            }
            else
            {
                anime.Session = new SessionViewModel();
            }

            return View(anime);
        }

        [HttpPost("Session/[action]")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> SaveSession([FromBody] SessionBody sessionBody)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var session = new Session()
            {
                Id = sessionBody.Id,
                CurrentEp = sessionBody.CurrentEp,
                CurrentTime = sessionBody.CurrentTime,
                UserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)),
                AnimeId = sessionBody.AnimeId,
            };

            await _sessionService.SaveSessionAsync(session);

            return Ok("Success");
        }
    }
}
