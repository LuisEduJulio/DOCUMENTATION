using DOCUMENTATION.APPLICATION.Commands.AuthorCommand;
using DOCUMENTATION.CORE.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.AuthorCommandHandler
{
    public class AuthorUpdateAdminCommandHandler : IRequestHandler<AuthorUpdateAdminCommand, Author>
    {
        public AuthorUpdateAdminCommandHandler()
        {

        }

        public Task<Author> Handle(AuthorUpdateAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
