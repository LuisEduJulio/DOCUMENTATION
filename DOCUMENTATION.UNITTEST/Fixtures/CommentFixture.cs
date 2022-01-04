using Bogus;
using DOCUMENTATION.CORE.Entities;

namespace DOCUMENTATION.UNITTEST.Fixtures
{
    public class CommentFixture
    {
        public static Comment CreateCommentWithId()
        {
            return new Faker<Comment>("pt_BR")
                .RuleFor(u => u.Id, faker => faker.Random.Number(10000))
                .RuleFor(u => u.Description, faker => faker.Lorem.Sentence())
                .RuleFor(u => u.AuthorId, faker => faker.Random.Number(10000))
                .RuleFor(u => u.ArticleId, faker => faker.Random.Number(10000));
        }
    }
}