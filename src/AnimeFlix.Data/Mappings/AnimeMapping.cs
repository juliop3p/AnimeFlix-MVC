using AnimeFlix.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Data.Mappings
{
    public class AnimeMapping : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasKey(anime => anime.Id);

            builder.Property(anime => anime.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(anime => anime.Image)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(anime => anime.Image)
                .IsRequired()
                .HasColumnType("varchar(300)");
        }
    }
}
