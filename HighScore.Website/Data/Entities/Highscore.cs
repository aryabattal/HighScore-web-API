using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HighScore.Website.Data.Entities
{
    public class Highscore
    {
        public Highscore(string playerName, DateTime date, int score)
        {
            PlayerName = playerName;
            Date = date;
            Score = score;
        }

        public Highscore(int highscoreId, string playerName, DateTime date, int score)
           : this(playerName, date, score)
        {
            HighscoreId = highscoreId;
        }

        public int HighscoreId { get; protected set; }
        
        [Required]
        public string PlayerName { get; protected set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Score { get; protected set; }

        public Game  Game{ get; set; }
        public int GameId { get; set; }
    }
}