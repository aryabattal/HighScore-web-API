using HighScore.Website.Areas.API.Models;
using HighScore.Website.Data.Entities;
using HighScores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        public readonly HighScoresContext context;

        public GamesController(HighScoresContext context)
        {
            this.context = context;
        }
        //GET /api/games
        [HttpGet]
        public IEnumerable<GameDto> GetAll()
        {
            var games = context.Games.ToList();

            //It's same:
            //var dto = games.Select(x => TogameDto(x));
            var dto = games.Select(TogameDto);

            return dto;
        }

        public GameDto TogameDto(Game game)
            => new GameDto
            {
                GameId = game.GameId,
                Name = game.Name,
                Description = game.Description,
                ReleaseYear = game.RealseYear,
                Genre = game.Genre,
                ImageUrl = game.ImageUrl
            };

        //GET /api/games/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<GameDto>> GetById(int id)
        //public IActionResult GetById(int id)

        {
            var game = await context.Games.FirstOrDefaultAsync(x => x.GameId == id);

            if (game == null)
            {
                return NotFound();
            }

            var dto = TogameDto(game);

            return dto;
            //return Ok(game);
        }
    
        [HttpPost]
        public ActionResult<GameDto> CreateGame(CreateGameDto createGameDto)
        {
            var game = new Game(
                createGameDto.Name,
                createGameDto.Description,
                createGameDto.ReleaseYear,
                createGameDto.Genre,
                createGameDto.ImageUrl);

            context.Games.Add(game);

            context.SaveChanges();
            // ändra entitet utan att vercka API

            var gameDto = TogameDto(game);

            //201 Created
            return CreatedAtAction(nameof(GetById), new { id = game.GameId }, gameDto);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var games = context.Games.Where(x => x.GameId == id);

            context.Games.RemoveRange(games);

            context.SaveChanges();

            //204 
            return NoContent();
        }

        }
}
