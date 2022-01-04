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
              .HasOne(p => p.Author)
              .WithMany(u => u.Topics)
              .HasForeignKey(u => u.AuthorId)
              .IsRequired()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}