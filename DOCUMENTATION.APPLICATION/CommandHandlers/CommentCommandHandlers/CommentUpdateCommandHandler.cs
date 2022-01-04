using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.APPLICATION.ModelView.CommentView;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.CommentCommandHandlers
{
    internal class CommentUpdateCommandHandler : IRequestHandler<CommentUpdateCommand, CommentView>
    {
        public CommentUpdateCommandHandler()
        {
        }

        public Task<CommentView> Handle(CommentUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}