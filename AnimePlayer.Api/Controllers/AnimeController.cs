using AnimePlayer.Api.Contracts;
using AnimePlayer.Core.Logger;
using AnimePlayer.Core.Models;
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
            LogAnimePlayer.Log.Debug($"{nameof(AnimeController)} - {nameof(AnimeController)}");
            _animeService = animeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeRequest>>> GetAnimes()
        {
            LogAnimePlayer.Log.Debug($"{nameof(AnimeController)} - {nameof(GetAnimes)}");

            var anime = await _animeService.GetAllAnime();

            var responce = anime.Select(a => new AnimeRequest(a.Id, a.Title, a.Description, a.YearIssue));

            return Ok(responce);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteAnime(Guid id)
        {
            return Ok(await _animeService.DeleteAnime(id));
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateAnime(Guid id, [FromBody] AnimeRequest request)
        {
            LogAnimePlayer.Log.Debug($"{nameof(AnimeController)} - {nameof(UpdateAnime)}");
            var animeId = await _animeService.UpdateAnime(
                id,
                request.Title,
                request.Description,
                request.YearIssue);

            return Ok(animeId);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateAnime([FromBody] AnimeRequest request)
        {
            LogAnimePlayer.Log.Debug($"{nameof(AnimeController)} - {nameof(CreateAnime)}");
            var anime = Anime.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description,
                request.YearIssue);

            if (anime.IsFailure)
            {
                return BadRequest(anime);
            }

            var animeId = await _animeService.CreateAnime(anime.Value);

            return Ok(animeId);
        }
    }
}
