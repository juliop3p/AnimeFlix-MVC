namespace AnimeFlix.Business.Models
{
    public class Anime : Entity
    {
        public string Name { get; set; }
        public string Imagem { get; set; }
        public string Url { get; set; }
        public Session Session { get; set; }
    }
}
