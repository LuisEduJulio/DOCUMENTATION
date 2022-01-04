using DOCUMENTATION.CORE.Entities;
using System;
using Xunit;

namespace DOCUMENTATION.UNITTEST.Entities
{
    public class TopicTest
    {
        [Fact]
        public void TestCreateTopic()
        {
            var comment = new Topic("Novo Modelo", "Teste de Unidade", 1, 2);

            Assert.Equal(comment.DateCreation.Date, DateTime.Now.Date);
            Assert.NotNull(comment.Title);
            Assert.NotNull(comment.Description);
            Assert.True(comment.TopicId != 0);
            Assert.True(comment.AuthorId != 0);
        }
    }
}