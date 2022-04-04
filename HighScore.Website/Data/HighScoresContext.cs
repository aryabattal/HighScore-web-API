using HighScore.Website.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace HighScores.Data
{
    public class HighScoresContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Highscore> HighScores { get; set; }
        public HighScoresContext(DbContextOptions<HighScoresContext> options)
            :base(options)
        {
           
        }
    }
}
