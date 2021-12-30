using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOCUMENTATION.INFRASTRUCTURE.Configurations
{
    public class ArchiveConfiguration : IEntityTypeConfiguration<Archive>
    {
        public void Configure(EntityTypeBuilder<Archive> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Topic)
                .WithMany()
                .IsRequired()
                .HasForeignKey(p => p.Id);
        }
    }
}