using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreManager
{
    class Game
    {
        public Game(string name, string description, int releaseYear, string genre, string imageUrl)
        {
            Name = name;
            Description = description;
            ReleaseYear = releaseYear;
            Genre = genre;
            ImageUrl = imageUrl;
        }

        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }
    }
}
