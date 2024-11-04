using AnimePlayer.Api.Contracts;
using AnimePlayer.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace AnimePlayer.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimeResponse>>> GetAnimes()
        {
            var anime = await _animeService.GetAllAnime();

            var responce = anime.Select(a => new AnimeResponse(a.Id, a.Title, a.Description, a.YearIssue));

            return Ok(responce);
        }
    }
}
