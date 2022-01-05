using DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler;
using DOCUMENTATION.APPLICATION.Commands.ArticlesCommand;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.UNITTEST.Fixtures;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DOCUMENTATION.UNITTEST.Handlers.ArticleCommandHandlers
{
    public class ArticleCreateCommandHandlerTest
    {
        private readonly AutoMocker _autoMocker;
        private readonly ArticleCreateCommandHandler _handler;
        private readonly Article _article;
        private readonly Topic _topic;
        private readonly Author _author;

        public ArticleCreateCommandHandlerTest()
        {
            _autoMocker = new AutoMocker();
            _handler = _autoMocker.CreateInstance<ArticleCreateCommandHandler>();

            _article = new ArticleFixture().CreateArticleNotId();
            _topic = new TopicFixture().CreateTopicWithId();
            _author = new AuthorFixture().CreateAuthorWithId();
        }

        protected ArticleCreateCommand CreateCommandNotId()
        {
            var command = new ArticleFixture().CreateArticleNotId();

            return new ArticleCreateCommand()
            {
                Description = command.Description,
                Title = command.Title,
                AuthorId = command.AuthorId,
                TopicId = command.TopicId
            };
        }

        [Fact]
        public async Task CreateArticle_Sucess()
        {
            //Arranje
            var articleRepository = new Mock<IArticleRepository>();
            var topicRepository = new Mock<ITopicRepository>();
            var authorRepository = new Mock<IAuthorRepository>();
            var mediator = new Mock<IMediator>();

            _autoMocker.GetMock<IArticleRepository>()
               .Setup(preferencesRepo => preferencesRepo.AddAsync(_article))
               .ReturnsAsync(new Article(_article.Title, _article.Description, _article.AuthorId, _article.TopicId));

            _autoMocker.GetMock<ITopicRepository>()
                .Setup(procedureRepo => procedureRepo.GetIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Topic(_topic.Title, _topic.Description, _topic.AuthorId, _topic.TopicId));

            _autoMocker.GetMock<IAuthorRepository>()
                .Setup(ticketRepo => ticketRepo.GetIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Author(_author.Name, _author.Description, _author.EAvatar));

            var command = CreateCommandNotId();

            var createArticleCommandHandler = new ArticleCreateCommandHandler(articleRepository.Object, topicRepository.Object, authorRepository.Object, mediator.Object);

            // Act
            var result = _handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Result == null);
            Assert.Null(result.Result);
        }
    }
}