using Bogus;
using DOCUMENTATION.CORE.Entities;

namespace DOCUMENTATION.UNITTEST.Fixtures
{
    public class RecordFixture
    {
        public static Record CreateRecordWithId()
        {
            return new Faker<Record>("pt_BR")
                .RuleFor(u => u.Id, faker => faker.Random.Number(10000))
                .RuleFor(u => u.Description, faker => faker.Lorem.Text())
                .RuleFor(u => u.AuthorId, faker => faker.Random.Number(10000))
                .RuleFor(u => u.TopicId, faker => faker.Random.Number(10000))
                .RuleFor(u => u.ArticleId, faker => faker.Random.Number(10000))
                .RuleFor(u => u.CommentId, faker => faker.Random.Number(10000));
        }
    }
}