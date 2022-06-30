using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.App.Models
{
    public class SessionBody
    {
        public Guid Id { get; set; }

        [Required]
        [Range(1, 2000)]
        public int CurrentEp { get; set; }

        [Required]
        [Range(0, 2000)]
        public int CurrentTime { get; set; }

        [Required]
        public Guid AnimeId { get; set; }
    }
}
