namespace AnimeFlix.Business.Models
{
    public class Session : Entity
    {
        public int CurrentEp { get; set; }
        public int CurrentTime { get; set; }

        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
        public Guid UserId { get; set; }
    }
}
