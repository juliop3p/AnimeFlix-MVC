using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.App.Models
{
    public class AnimeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Imagem")]
        public string Image { get; set; }

        public string Url { get; set; }

        public SessionViewModel Session { get; set; }
    }
}
