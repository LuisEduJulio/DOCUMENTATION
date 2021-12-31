using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOCUMENTATION.INFRASTRUCTURE.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                 .HasOne(b => b.Topic)
                 .WithMany(i => i.Articles)
                 .HasForeignKey(b => b.TopicId);

            builder
               .HasMany(p => p.Comments)
               .WithOne()
               .HasForeignKey(u => u.ArticleId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(b => b.Author)
                .WithMany(i => i.Articles)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}