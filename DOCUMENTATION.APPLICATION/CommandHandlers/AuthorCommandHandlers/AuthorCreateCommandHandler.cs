using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.APPLICATION.Commands.RecordCommands;
using DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators;
using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Enums;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Author>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMediator _mediator;

        public AuthorCreateCommandHandler(IAuthorRepository authorRepository, IMediator mediator)
        {
            _authorRepository = authorRepository;
            _mediator = mediator;
        }

        public async Task<Author> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            var validation = await new AuthorCreateCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = new Author(request.Name, request.Description, EAvatar.DEFAULT);

            var authorCreate = await _authorRepository.AddAsync(author);

            await _mediator.Send(new RecordCreateCommand()
            {
                EStatusRecord = EStatusRecord.CREATE,
                Description = $"Autor {author.Name} criado.",
                AuthorId = author.Id
            }, cancellationToken);

            return authorCreate;
        }
    }
}