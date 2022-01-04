using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Enums;
using System;
using Xunit;

namespace DOCUMENTATION.UNITTEST.Entities
{
    public class AuthorTest
    {
        [Fact]
        public void TestCreateAuthor()
        {
            var author = new Author("João Alberto", "Desenvolvedor", EAvatar.CRAZY);

            Assert.Equal(author.DateCreation.Date, DateTime.Now.Date);
            Assert.NotNull(author.Name);
            Assert.NotNull(author.Description);
            Assert.True(author.EAvatar == EAvatar.CRAZY);
        }
    }
}