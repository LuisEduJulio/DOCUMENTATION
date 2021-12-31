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
                .HasForeignKey(u => u.TopicId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(p => p.Archives)
               .WithOne()
               .HasForeignKey(u => u.Id)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}