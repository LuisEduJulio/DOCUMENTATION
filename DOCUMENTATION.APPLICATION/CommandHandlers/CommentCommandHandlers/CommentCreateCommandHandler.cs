using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.ModelView.CommentView;
using DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Enums;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.CommentCommandHandlers
{
    public class CommentCreateCommandHandler : IRequestHandler<CommentCreateCommand, CommentView>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public CommentCreateCommandHandler(ICommentRepository commentRepository, IArticleRepository articleRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _articleRepository = articleRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<CommentView> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new CommentCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.AuthorId);

            if (author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            var article = await _articleRepository.GetIdAsync(request.ArticleId);

            if (article == null)
            {
                throw new CustomException("Artigo não existe!");
            }

            var comment = new Comment(request.Description, author.Id, article.Id);

            var commentCreate = await _commentRepository.AddAsync(comment);

            var returnComment = new CommentView(
                commentCreate.Description,
                commentCreate.AuthorId,
                commentCreate.ArticleId,
                commentCreate.DateCreation
            );

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.CREATE,
                Description = $"{author.Name} Comentou {commentCreate.Description} no artigo {article.Description}",
                AuthorId = article.AuthorId,
                ArticleId = article.Id
            }, cancellationToken);

            return returnComment;
        }
    }
}