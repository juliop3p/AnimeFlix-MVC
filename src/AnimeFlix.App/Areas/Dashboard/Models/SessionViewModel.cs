namespace AnimeFlix.App.Areas.Dashboard.Models
{
    public class SessionViewModel
    {
        public int CurrentEp { get; set; }
        public int CurrentTime { get; set; }

        public Guid AnimeId { get; set; }
        public AnimeViewModel Anime { get; set; }
        public Guid UserId { get; set; }
    }
}