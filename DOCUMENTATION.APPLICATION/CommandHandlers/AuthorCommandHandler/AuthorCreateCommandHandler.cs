using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.CORE.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorCreateCommandHandler : IRequestHandler<AuthorCreateCommand, Author>
    {
        public AuthorCreateCommandHandler()
        {

        }

        public Task<Author> Handle(AuthorCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
