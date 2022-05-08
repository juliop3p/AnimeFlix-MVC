using AnimeFlix.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Data.Context
{
    public class AnimeFlixContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public AnimeFlixContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimeFlixContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
