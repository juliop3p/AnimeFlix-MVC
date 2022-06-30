namespace AnimeFlix.Business.Entities
{
    public class Session : BaseEntity
    {
        public int CurrentEp { get; set; }
        public int CurrentTime { get; set; }

        public Guid UserId { get; set; }

        public Guid AnimeId { get; set; }
        public Anime Anime { get; set; }
    }
}