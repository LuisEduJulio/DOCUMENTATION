using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOCUMENTATION.INFRASTRUCTURE.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(p => p.Topics)
                .WithOne()
                .IsRequired(false)
                .HasForeignKey(u => u.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(p => p.Archives)
               .WithOne()
               .IsRequired(false)
               .HasForeignKey(u => u.Id)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}