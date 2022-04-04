using HighScore.Website.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HighScore.Website.Models.ViewModels
{
    public class CreateHighScoresViewModel
    {
        [Required]
        [MaxLength(50)]
        public string PlayerName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime  Date { get; set; }

        public int Score { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
