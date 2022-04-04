using HighScore.Website.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.API.Models
{
    public class HighScoreDto
    {
      

        public int HighscoreId { get;  set; }

        public string PlayerName { get;  set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Score { get;  set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
