using AnimeFlix.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Data.Mappings
{
    public class SessionMapping : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(session => session.Id);

            builder.Property(session => session.CurrentTime)
                .IsRequired();

            builder.Property(session => session.CurrentEp)
                .IsRequired();

            builder.Property(session => session.UserId)
                .IsRequired();

            builder.Property(session => session.AnimeId)
                .IsRequired();

            builder.HasOne(session => session.Anime)
                .WithOne(anime => anime.Session);
        }
    }
}
