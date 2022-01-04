using Bogus;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Enums;

namespace DOCUMENTATION.UNITTEST.Fixtures
{
    public class AuthorFixture
    {
        public static Author CreateAuthorWithId()
        {
            return new Faker<Author>("pt_BR")
                .RuleFor(u => u.Id, faker => faker.Random.Number(10000))
                .RuleFor(u => u.Name, faker => faker.Person.FirstName)
                .RuleFor(u => u.Description, faker => faker.Person.UserName)
                .RuleFor(u => u.EAvatar, _ => EAvatar.DEFAULT);
        }
    }
}