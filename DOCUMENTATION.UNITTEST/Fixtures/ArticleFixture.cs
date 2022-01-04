using Bogus;
using DOCUMENTATION.CORE.Entities;

namespace DOCUMENTATION.UNITTEST.Fixtures
{
    public class ArticleFixture
    {
        public static Article CreateArticleWithId()
        {
            return new Faker<Article>("pt_BR")
                .RuleFor(u => u.Id, faker => faker.Random.Number(10000))
                .RuleFor(u => u.Title, faker => faker.Lorem.Sentences())
                .RuleFor(u => u.Description, faker => faker.Lorem.Text())
                .RuleFor(u => u.TopicId, faker => faker.Random.Number(10000))
                .RuleFor(u => u.AuthorId, faker => faker.Random.Number(10000));
        }
    }
}