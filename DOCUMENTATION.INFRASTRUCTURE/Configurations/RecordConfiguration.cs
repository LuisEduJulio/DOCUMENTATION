using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOCUMENTATION.INFRASTRUCTURE.Configurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                 .HasOne(b => b.Topic)
                 .WithMany(r => r.Records)
                 .HasForeignKey(b => b.TopicId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(b => b.Article)
                 .WithMany(r => r.Records)
                 .HasForeignKey(b => b.ArticleId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(b => b.Comment)
                 .WithMany(r => r.Records)
                 .HasForeignKey(b => b.CommentId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder
                 .HasOne(b => b.Author)
                 .WithMany(r => r.Records)
                 .HasForeignKey(b => b.AuthorId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
