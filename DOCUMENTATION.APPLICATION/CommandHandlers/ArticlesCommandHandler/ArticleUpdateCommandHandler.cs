using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using DOCUMENTATION.APPLICATION.ModelView.ArticleView;
using DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler
{
    public class ArticleUpdateCommandHandler : IRequestHandler<ArticleUpdateCommand, ArticleView>
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleUpdateCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleView> Handle(ArticleUpdateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new ArticleUpdateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var article = await _articleRepository.GetIdAsync(request.Id);

            if (article == null)
            {
                throw new CustomException("Tópico não existe!");
            }

            article.Title = request.Title ?? article.Title;
            article.Description = request.Description ?? article.Description;
            article.DateUpdated = DateTime.Now;

            var topicUpdate = await _articleRepository.UpdateAsync(article);

            var retunrArticle = new ArticleView(topicUpdate.Title, topicUpdate.Description, topicUpdate.AuthorId, topicUpdate.TopicId, topicUpdate.DateCreation);

            return retunrArticle;
        }
    }
}
