using DOCUMENTATION.APPLICATION.Commands.CommentCommand;
using DOCUMENTATION.APPLICATION.ModelView.CommentView;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DOCUMENTATION.APPLICATION.CommandHandlers.CommentCommandHandlers
{
    public class CommentUpdateDisableCommandHandler : IRequestHandler<CommentUpdateDisableCommand, CommentView>
    {
        public CommentUpdateDisableCommandHandler()
        {
        }

        public Task<CommentView> Handle(CommentUpdateDisableCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}