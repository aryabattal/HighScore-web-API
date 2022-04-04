using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighScoreManager
{
    class HighScore
    {
        public HighScore()
        { 
        
        }
        public HighScore(string playerName, string date, int score)
        {
            PlayerName = playerName;
            Date = date;
            Score = score;
        }

     
        public HighScore(int gameId, string playerName, string date, int score)
        {
            GameId = gameId;
            PlayerName = playerName;
            Date = date;
            Score = score;
        }

        public HighScore(int id, string playerName, string date, int score, int gameId)
        {
            Id = id;
            PlayerName = playerName;
            Date = date;
            Score = score;
            GameId = gameId;
        }
        public int Id { get;  set; }
        public string PlayerName { get;  set; }
        public string Date { get; set; }
        public int Score { get;  set; }
        public int GameId { get; set; }

    }
}
