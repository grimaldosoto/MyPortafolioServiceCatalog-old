using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistences.Contexts.Configurations
{
    public class TechnologyConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technology", "MyPortafolio");

            builder.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Version)
                .HasMaxLength(10)
                .IsUnicode(false);
        }
    }
}
