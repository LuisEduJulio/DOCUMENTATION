using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Validators.CommentCommandValidators;
using DOCUMENTATION.CORE.Enums;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.CommentCommandHandlers
{
    public class CommentUpdateDisableCommandHandler : IRequestHandler<CommentUpdateDisableCommand, Unit>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public CommentUpdateDisableCommandHandler(ICommentRepository commentRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CommentUpdateDisableCommand request, CancellationToken cancellationToken)
        {
            var validation = await new CommentUpdateDisableCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var comment = await _commentRepository.GetIdAsync(request.Id);

            if (comment == null)
            {
                throw new CustomException("Comentário não existe!");
            }

            comment.DateUpdated = DateTime.Now;
            comment.DateDeleted = DateTime.Now;

            var disableComment = await _commentRepository.UpdateAsync(comment);

            var author = await _authorRepository.GetIdAsync(disableComment.AuthorId);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.CREATE,
                Description = $"{author.Name} excluiu o {disableComment.Description} do artigo {disableComment.Description}.",
                AuthorId = disableComment.AuthorId,
                ArticleId = disableComment.Id
            }, cancellationToken);

            return Unit.Value;
        }
    }
}