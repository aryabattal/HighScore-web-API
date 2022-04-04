using HighScore.Website.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.API.Models
{
    public class GameDto
    { 
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Highscore> HighScores { get; set; }
       = new List<Highscore>();

        public Highscore HighestRecord
        {
            get
            {
                var highestScore = HighScores.Select(x => x.Score).Prepend(0).Max();

                return HighScores.FirstOrDefault(x => x.Score == highestScore);
            }

        }
    }
}
