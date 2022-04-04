using HighScore.Website.Models.ViewModels;
using HighScore.Website.Data.Entities;
using HighScores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.Admin.Controllers
{

    public class HighScoresController : Controller
    {
        private readonly HighScoresContext context;

        public HighScoresController(HighScoresContext context)
        {
            this.context = context;
        }
        // GET: /HighScores/new

        
        public IActionResult New()
        {
            // Games for dropdown box
            var games = context.Games.ToList()
                .Select(c => new SelectListItem { Value = c.GameId.ToString(), Text = c.Name.ToString() }).ToList();

            ViewBag.games = games;

          
            return View();
        }

        // POST: HighScores/new

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(CreateHighScoresViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve associated game (in case of unselection, Game id will be set to default value "0")
                string gameIdString = Request.Form["Games"];
                bool gameIdIsValid = int.TryParse(gameIdString, out int gameIdParsed);
                int gameId = gameIdIsValid ? gameIdParsed : 0;
                var associatedGame =  context.Games.Find(gameId);

                var highScore = new Highscore(
                        viewModel.PlayerName,
                        viewModel.Date,
                        viewModel.Score
                        );
            
               highScore.Game = associatedGame;

                context.Add(highScore);
                
                await context.SaveChangesAsync();
              
                return RedirectToAction("Index","Home");
            }

            return View(viewModel);
        }
    }
}
