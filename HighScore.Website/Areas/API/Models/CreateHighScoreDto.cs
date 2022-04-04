using HighScore.Website.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HighScore.Website.Areas.API.Models
{
    public class CreateHighScoreDto
    {
        [Required]
        [MaxLength(50)]
        public string PlayerName { get; protected set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Score { get; protected set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
