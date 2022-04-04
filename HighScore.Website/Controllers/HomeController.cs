using HighScore.Website.Models;
using HighScores.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace HighScore.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly HighScoresContext context;

        public HomeController(HighScoresContext context)
            => this.context = context;

        //GET 
        //GET /home
        //GET /home/index
        public IActionResult Index()
        {
          // Retrieve games and related highscore lists
            var games = context.Games.Include(x => x.HighScores);

            var highScore = context.HighScores.ToList();

            ViewBag.hidhScore = highScore;
            ViewBag.Game = games;

            return View(games);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
