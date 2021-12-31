using DOCUMENTATION.CORE.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DOCUMENTATION.INFRASTRUCTURE.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(b => b.Article)
                .WithMany(i => i.Comments)
                .HasForeignKey(b => b.ArticleId);

            builder
                .HasOne(b => b.Author)
                .WithMany(i => i.Comments)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}