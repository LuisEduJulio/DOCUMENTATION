using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.ModelView.AuthorView;
using DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators;
using DOCUMENTATION.CORE.Enums;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorUpdateAdminCommandHandler : IRequestHandler<AuthorUpdateAdminCommand, AuthorView>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public AuthorUpdateAdminCommandHandler(IAuthorRepository authorRepository, IMediator mediator)
        {
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<AuthorView> Handle(AuthorUpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var validation = await new AuthorUpdateAdminCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.Id);

            if (author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            author.Admin = request.Admin;
            author.DateUpdated = DateTime.Now;

            var authorCreate = await _authorRepository.UpdateAsync(author);

            var returnAuthor = new AuthorView(
               authorCreate.Name,
               authorCreate.Description,
               authorCreate.Admin,
               authorCreate.EAvatar,
               authorCreate.DateUpdated
           );

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.UPDATE,
                Description = $"Autor {author.Name} alterado.",
                AuthorId = author.Id
            }, cancellationToken);

            return returnAuthor;
        }
    }
}