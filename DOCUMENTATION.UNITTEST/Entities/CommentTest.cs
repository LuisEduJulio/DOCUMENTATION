using DOCUMENTATION.CORE.Entities;
using System;
using Xunit;

namespace DOCUMENTATION.UNITTEST.Entities
{
    public class CommentTest
    {
        [Fact]
        public void TestCreateComment()
        {
            var comment = new Comment("Gostei do seu artigo", 1, 2);

            Assert.Equal(comment.DateCreation.Date, DateTime.Now.Date);
            Assert.NotNull(comment.Description);
            Assert.True(comment.ArticleId != 0);
            Assert.True(comment.AuthorId != 0);
        }
    }
}