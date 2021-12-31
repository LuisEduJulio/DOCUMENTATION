using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.CORE.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.CommentCommandHandlers
{
    public class CommentCreateCommandHandler : IRequestHandler<CommentCreateCommand, Comment>
    {
        public CommentCreateCommandHandler()
        {

        }

        public Task<Comment> Handle(CommentCreateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
