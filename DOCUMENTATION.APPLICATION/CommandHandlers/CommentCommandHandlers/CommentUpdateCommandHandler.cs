using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.ModelView.CommentView;
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
    internal class CommentUpdateCommandHandler : IRequestHandler<CommentUpdateCommand, CommentView>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public CommentUpdateCommandHandler(ICommentRepository commentRepository, IAuthorRepository authorRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<CommentView> Handle(CommentUpdateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new CommentUpdateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var comment = await _commentRepository.GetIdAsync(request.Id);

            if (comment == null)
            {
                throw new CustomException("Comentário não existe!");
            }

            comment.Description = request.Description ?? comment.Description;
            comment.DateUpdated = DateTime.Now;

            var commentUpdate = await _commentRepository.UpdateAsync(comment);

            var returnComment = new CommentView(commentUpdate.Description, commentUpdate.AuthorId, commentUpdate.ArticleId, commentUpdate.DateCreation);

            var author = await _authorRepository.GetIdAsync(commentUpdate.AuthorId);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.UPDATE,
                Description = $"{author.Name} modificou o comentário {commentUpdate.Description}.",
                AuthorId = commentUpdate.AuthorId,
                ArticleId = commentUpdate.Id
            }, cancellationToken);

            return returnComment;
        }
    }
}