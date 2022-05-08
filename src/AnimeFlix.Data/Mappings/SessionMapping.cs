using AnimeFlix.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimeFlix.Data.Mappings
{
    public class SessionMapping : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.CurrentEp)
                .IsRequired()
                .HasMaxLength(5000);

            builder.Property(s => s.CurrentTime)
                .IsRequired();

            builder.ToTable("Sessions");

        }
    }
}
