using DOCUMENTATION.APPLICATION.Commands.ArticleCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Validators.ArticleCommandValidators;
using DOCUMENTATION.CORE.Enums;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.ArticlesCommandHandler
{
    internal class ArticleUpdateDisableCommandHandler : IRequestHandler<ArticleUpdateDisableCommand, Unit>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public ArticleUpdateDisableCommandHandler(IArticleRepository articleRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
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

            var articleDisable = await _articleRepository.UpdateAsync(article);

            var author = await _authorRepository.GetIdAsync(articleDisable.AuthorId);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.DISABLE,
                Description = $"Artigo desativado em {DateTime.Now} por {author.Name}",
                AuthorId = articleDisable.AuthorId,
                TopicId = articleDisable.TopicId,
                ArticleId = articleDisable.Id
            }, cancellationToken);

            return Unit.Value;
        }
    }
}