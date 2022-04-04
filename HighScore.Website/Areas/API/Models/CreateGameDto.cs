using System.ComponentModel.DataAnnotations;

namespace HighScore.Website.Areas.API.Models
{
    public class CreateGameDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }

    }
}
