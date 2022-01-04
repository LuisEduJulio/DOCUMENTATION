using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
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

        public AuthorCreateCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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

            return authorCreate;
        }
    }
}