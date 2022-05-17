using AnimeFlix.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Data.Mappings
{
    public class AnimeMapping : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Imagem)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(a => a.Url)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(a => a.Session)
                .WithOne(s => s.Anime);

            builder.ToTable("Animes");
        }
    }
}
