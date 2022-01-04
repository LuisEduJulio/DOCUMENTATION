using DOCUMENTATION.CORE.Entities;
using System;
using Xunit;

namespace DOCUMENTATION.UNITTEST.Entities
{
    public class ArticleTest
    {
        [Fact]
        public void TestCreateArticle()
        {
            var article = new Article("Novo Artigo", "Artigo de Teste", 1, 2);

            Assert.Equal(article.DateCreation.Date, DateTime.Now.Date);
            Assert.True(article.AuthorId != 0);
            Assert.True(article.TopicId != 0);
            Assert.NotNull(article.Title);
            Assert.NotNull(article.Description);
        }
    }
}