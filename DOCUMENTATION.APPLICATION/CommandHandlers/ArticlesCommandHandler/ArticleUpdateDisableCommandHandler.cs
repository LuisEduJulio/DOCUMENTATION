using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
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
    class ArticleUpdateDisableCommandHandler : IRequestHandler<ArticleUpdateDisableCommand, Unit>
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleUpdateDisableCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(ArticleUpdateDisableCommand request, CancellationToken cancellationToken)
        {
            var validation = await new ArticleUpdateDisableCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var article = await _articleRepository.GetIdAsync(request.Id);

            if (article == null)
            {
                throw new CustomException("Tópico não existe!");
            }

            article.DateUpdated = DateTime.Now;
            article.DateDeleted = DateTime.Now;

            await _articleRepository.UpdateAsync(article);

            return Unit.Value;
        }
    }
}
