namespace AnimeFlix.Business.Entities
{
    public class Anime : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        
        public Session Session { get; set; }
    }
}
