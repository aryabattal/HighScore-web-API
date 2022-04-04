using HighScores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Controllers
{
    public class GamesController : Controller
    {
        private readonly HighScoresContext context;

        public GamesController(HighScoresContext context)
        {
            this.context = context;
        }

        // GET /games/tetris
        [Route("/games/{name}", Name = "gamesdetails")]
        public  async Task<IActionResult> Details(string name)
        {
            if (name == "")
            {
                return NotFound();
            }
           // Fetch all games from database
            var game =await context.Games
                // including all highscores lists that are associated with each of the games
                .Include(g => g.HighScores)
                // then pick out only that game, that has the same name as the passed parameter "string name"
                .FirstOrDefaultAsync(x => x.Name == name);
               

            if (game == null)
            {
                return NotFound();
            }
            // return picked out specific game with the specific highscore list
            return View(game);
        }
    }
}
