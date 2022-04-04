using System;
using System.Collections.Generic;
using System.Linq;

namespace HighScore.Website.Data.Entities
{
    public class Game
    {
     
        public Game(string name)
        {
            Name = name;
        }

      
        public Game(string name, string description, int releaseYear, string genre, string imageUrl) : this(name)
        {
            Description = description;
            RealseYear = releaseYear;
            Genre = genre;
            ImageUrl = imageUrl;
        }

        public int GameId { get; set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Genre { get; protected set; }
        public int RealseYear { get; protected set; }
        public string ImageUrl { get; protected set; }
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

