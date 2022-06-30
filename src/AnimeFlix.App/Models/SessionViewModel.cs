using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.App.Models
{
    public class SessionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int CurrentEp { get; set; } = 1;

        [Required]
        public int CurrentTime { get; set; } = 0;

        public Guid UserId { get; set; }

        public Guid AnimeId { get; set; }
        public AnimeViewModel Anime { get; set; }
    }
}
