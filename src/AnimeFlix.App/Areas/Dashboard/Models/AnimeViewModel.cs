using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.App.Areas.Dashboard.Models
{
    public class AnimeViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required]
        public string Imagem { get; set; }

        public string Url { get; set; }


        public SessionViewModel Session { get; set; }
    }
}
