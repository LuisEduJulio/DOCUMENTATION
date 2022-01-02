using DOCUMENTATION.APPLICATION.Commands.ArticlesCommand;
using DOCUMENTATION.APPLICATION.ModelView.ArticleView;
using DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler
{
    public class ArticleCreateCommandHandler : IRequestHandler<ArticleCreateCommand, ArticleView>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITopicRepository _topicRepository;
        private readonly IAuthorRepository _authorRepository;
        public ArticleCreateCommandHandler(IArticleRepository articleRepository, ITopicRepository topicRepository, IAuthorRepository authorRepository)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _topicRepository = topicRepository;
        }
        public async Task<ArticleView> Handle(ArticleCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new ArticleCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.AuthorId);

            if (author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            var topic = await _topicRepository.GetIdAsync(request.TopicId);

            if (topic == null)
            {
                throw new CustomException("Tópico não existe!");
            }

            var article = new Article(request.Title, request.Description, author.Id, topic.Id);

            var articlerCreate = await _articleRepository.AddAsync(article);

            var returnArticle = new ArticleView(
                articlerCreate.Title,
                articlerCreate.Description,
                articlerCreate.AuthorId,
                articlerCreate.TopicId,
                articlerCreate.DateCreation
            );

            return returnArticle;
        }
    }
}
