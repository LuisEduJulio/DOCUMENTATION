using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.APPLICATION.ModelView.AuthorView;
using DOCUMENTATION.APPLICATION.Validators.AuthorCommandValidators;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorUpdateAvatarCommandHandler : IRequestHandler<AuthorUpdateAvatarCommand, AuthorView>
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorUpdateAvatarCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<AuthorView> Handle(AuthorUpdateAvatarCommand request, CancellationToken cancellationToken)
        {
            var validation = await new AuthorUpdateAvatarCommandValidator().ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new CustomException(validation.Errors.First().ErrorMessage);
            }

            var author = await _authorRepository.GetIdAsync(request.Id);

            if (author == null)
            {
                throw new CustomException("Autor não existe!");
            }

            if (author.EAvatar == request.EAvatar)
            {
                throw new CustomException("Informe um avater diferente!");
            }

            author.EAvatar = request.EAvatar;
            author.DateUpdated = DateTime.Now;

            var UpdateAuthor = await _authorRepository.UpdateAsync(author);

            var returnAuthor = new AuthorView(
                UpdateAuthor.Name,
                UpdateAuthor.Description,
                UpdateAuthor.Admin,
                UpdateAuthor.EAvatar,
                UpdateAuthor.DateUpdated
            );

            return returnAuthor;
        }
    }
}