using AnimeFlix.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.Data.Context
{
    public class AnimeFlixContext : DbContext
    {
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public AnimeFlixContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(200)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AnimeFlixContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
