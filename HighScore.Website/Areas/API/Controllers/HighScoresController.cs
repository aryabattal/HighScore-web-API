using HighScore.Website.Areas.API.Models;
using HighScore.Website.Data.Entities;
using HighScores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HighScoresController : ControllerBase
    {
        private readonly HighScoresContext context;

        public HighScoresController(HighScoresContext context)
        {
            this.context = context;
        }

        //GET /api/Highscores
        [HttpGet]
        public IEnumerable<HighScoreDto> GetHighScores()
        {
            var highscores = context.HighScores.ToList();

            var dto = highscores.Select(ToHighScoreDto);

            return dto;
        }

  

        //GET: api/highScore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Highscore>> GetHighScore(int id)
        {
            var highScore = await context.HighScores.FindAsync(id);

            if (highScore == null)
            {
                return NotFound();
            }

            return highScore;
        }

       

        [HttpPost]
        public async Task<ActionResult<Highscore>> PostHighScore(HighScoreDto HighScoreDto)
        {
            var highScore = new Highscore(
                HighScoreDto.HighscoreId,
                HighScoreDto.PlayerName,
                HighScoreDto.Date,
                HighScoreDto.Score );

            var game = await context.Games.FirstOrDefaultAsync(c => c.GameId == HighScoreDto.GameId);

            highScore.Game =game;

            context.HighScores.Add(highScore);

            await context.SaveChangesAsync();

            var highScoredto = ToHighScoreDto(highScore);

            return CreatedAtAction(nameof(GetHighScore), new { id = highScoredto.HighscoreId }, highScoredto);
        }

        public HighScoreDto ToHighScoreDto(Highscore highScore)
        => new HighScoreDto
        {
           HighscoreId = highScore.HighscoreId,
            PlayerName = highScore.PlayerName,
            Date = highScore.Date,
            Score = highScore.Score,
            GameId = highScore.GameId,
        };
    }
}
